// <copyright file="RapidLaunchPublisherTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Moq;
using NMediation.Abstractions;
using RapidLaunch.Common;

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
            var mediation = new Mock<IMediation>();
            mediation.Setup(x => x.Publish(It.IsAny<TestNotification>(), CancellationToken.None))
                .Returns(Task.CompletedTask);

            var publisher = new RapidLaunchPublisher(mediation.Object);

            await publisher.PublishDomainEvent(new TestNotification(), CancellationToken.None);

            mediation.Verify(x => x.Publish(It.IsAny<IOccurrence>(), CancellationToken.None), Times.Once);
        }
    }
}
