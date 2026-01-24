// <copyright file="RapidLaunchPublisherRepositoryTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NMediation.Abstractions;
using NMediation.Dependencies;
using RapidLaunch.Common;
using RapidLaunch.EF.Common;
using RapidLaunch.EF.Tests.GuidPrimary;
using RapidLaunch.EF.Tests.Helpers;
using System.Reflection;

namespace RapidLaunch.EF.Tests.Common
{
    /// <summary>
    /// Tests for the <see cref="RapidLaunchPublisherRepository{TRoot, TId, TEvent}"/> class.
    /// </summary>
    [TestClass]
    public class RapidLaunchPublisherRepositoryTests : BaseIntegrationTest
    {
        private readonly IPublishingBus<IOccurrence> _bus;
        private readonly Mock<IOccurrenceHandler<IOccurrence>> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherRepositoryTests"/> class.
        /// </summary>
        public RapidLaunchPublisherRepositoryTests()
        {
            _handler = new Mock<IOccurrenceHandler<IOccurrence>>();
            _handler.Setup(x => x.Handle(It.IsAny<TestNotification>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var collection = new ServiceCollection();

            collection.AddTransient(_ => _handler.Object);

            collection.AddNMediation(Assembly.GetExecutingAssembly());

            var provider = collection.BuildServiceProvider();

            var mediation = provider.GetRequiredService<IMediation>();

            _bus = new RapidLaunchPublisher(mediation);
        }

        /// <summary>
        /// Default include statement works correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task ConstructorWithIncludeFuncWorksCorrectly()
        {
            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestPublisherRepository(context, _bus);

                await repo.AddRootsAsync(
                    new List<TestGuidEntity>
                {
                    new TestGuidEntity { Relationship = new TestRelationship() },
                    new TestGuidEntity { Relationship = new TestRelationship() },
                },
                    CancellationToken.None);
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestPublisherRepository(context, _bus, queryable => queryable.Include(root => root.Relationship));

                results = await repo.GetAllRootsAsync(CancellationToken.None);
            }

            Assert.HasCount(2, results);
            Assert.IsTrue(results.All(root => root.Relationship != null));
        }

        /// <summary>
        /// Publishing of events is correct.
        /// </summary>
        [TestMethod]
        public void PublishingEventsWorksCorrectly()
        {
            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestPublisherRepository(context, _bus);

                var root = new TestGuidEntity();
                root.AddEvent();

                repo.AddRoots(new List<TestGuidEntity> { root });
            }

            _handler.Verify(x => x.Handle(It.IsAny<TestNotification>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        /// Publishing of events async is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task PublishingEventsAsyncWorksCorrectly()
        {
            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestPublisherRepository(context, _bus);

                var root = new TestGuidEntity();
                root.AddEvent();

                await repo.AddRootsAsync(new List<TestGuidEntity> { root }, CancellationToken.None);
            }

            _handler.Verify(x => x.Handle(It.IsAny<TestNotification>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
