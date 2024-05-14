// <copyright file="RapidLaunchPublisherRepositoryTests.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RapidLaunch.Common;
using RapidLaunch.EF.Common;
using RapidLaunch.EF.Tests.Helpers;

namespace RapidLaunch.EF.Tests.Common
{
    /// <summary>
    /// Tests for the <see cref="RapidLaunchPublisherRepository{TEntity,TId}"/> class.
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

                await repo.AddEntitiesAsync(new List<TestEntity>
                {
                    new TestEntity { Relationship = new TestRelationship() },
                    new TestEntity { Relationship = new TestRelationship() },
                });
            }

            List<TestEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestPublisherRepository(context, _bus, queryable => queryable.Include(entity => entity.Relationship));

                results = await repo.GetAllEntitiesAsync();
            }

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.All(entity => entity.Relationship != null));
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

                var entity = new TestEntity();
                entity.AddEvent();

                repo.AddEntities(new List<TestEntity> { entity });
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

                var entity = new TestEntity();
                entity.AddEvent();

                await repo.AddEntitiesAsync(new List<TestEntity> { entity });
            }

            _handler.Verify(x => x.HandleDomainEvent(It.IsAny<TestNotification>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
