// <copyright file="RapidLaunchPublisherRepositoryTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RapidLaunch.Common;
using RapidLaunch.EF.Common;
using RapidLaunch.EF.Tests.GuidPrimary;
using RapidLaunch.EF.Tests.Helpers;

namespace RapidLaunch.EF.Tests.Common
{
    /// <summary>
    /// Tests for the <see cref="RapidLaunchPublisherRepository{TRoot,TId}"/> class.
    /// </summary>
    [TestClass]
    public class RapidLaunchPublisherRepositoryTests : BaseIntegrationTest
    {
        private readonly IPublishingBus _bus;
        private readonly Mock<IDomainEventHandler<IDomainEvent>> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherRepositoryTests"/> class.
        /// </summary>
        public RapidLaunchPublisherRepositoryTests()
        {
            _handler = new Mock<IDomainEventHandler<IDomainEvent>>();
            _handler.Setup(x => x.HandleDomainEvent(It.IsAny<TestNotification>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var collection = new ServiceCollection();

            collection.AddTransient(_ => _handler.Object);

            var provider = collection.BuildServiceProvider();

            _bus = new RapidLaunchPublisher(provider);
        }

        /// <summary>
        /// Default include statement works correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task Constructor_WithIncludeFunc_WorksCorrectly()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new TestPublisherRepository(context, _bus);

                await repo.AddRootsAsync(new List<TestGuidEntity>
                {
                    new TestGuidEntity { Relationship = new TestRelationship() },
                    new TestGuidEntity { Relationship = new TestRelationship() },
                });
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestPublisherRepository(context, _bus, queryable => queryable.Include(root => root.Relationship));

                results = await repo.GetAllRootsAsync();
            }

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.All(root => root.Relationship != null));
        }

        /// <summary>
        /// Publishing of events is correct.
        /// </summary>
        [TestMethod]
        public void PublishingEvents_WorksCorrectly()
        {
            using (var context = new TestDbContext())
            {
                var repo = new TestPublisherRepository(context, _bus);

                var root = new TestGuidEntity();
                root.AddEvent();

                repo.AddRoots(new List<TestGuidEntity> { root });
            }

            _handler.Verify(x => x.HandleDomainEvent(It.IsAny<TestNotification>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        /// <summary>
        /// Publishing of events async is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task PublishingEventsAsync_WorksCorrectly()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new TestPublisherRepository(context, _bus);

                var root = new TestGuidEntity();
                root.AddEvent();

                await repo.AddRootsAsync(new List<TestGuidEntity> { root });
            }

            _handler.Verify(x => x.HandleDomainEvent(It.IsAny<TestNotification>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
