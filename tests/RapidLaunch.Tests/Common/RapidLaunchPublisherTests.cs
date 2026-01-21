// <copyright file="RapidLaunchPublisherTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using Moq;
using NMediation.Abstractions;

namespace RapidLaunch.Tests.Common
{
    /// <summary>
    /// Tests for the <see cref="RapidLaunchPublisher"/> class.
    /// </summary>
    [TestClass]
    public class RapidLaunchPublisherTests
    {
        /// <summary>
        /// The publisher should publish the correct amount of events.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task PublishDomainEventPublishesEvents()
        {
            var handler = new Mock<IOccurrenceHandler<TestNotification>>();
            handler.Setup(x => x.Handle(It.IsAny<TestNotification>(), CancellationToken.None))
                .Returns(Task.CompletedTask);

            var collection = new ServiceCollection();

            collection.AddTransient(_ => handler.Object);

            var provider = collection.BuildServiceProvider();

            var publisher = new RapidLaunchPublisher(provider);

            await publisher.PublishDomainEvent(new TestNotification());

            handler.Verify(x => x.Handle(It.IsAny<TestNotification>(), CancellationToken.None), Times.Once);
        }
    }
}
