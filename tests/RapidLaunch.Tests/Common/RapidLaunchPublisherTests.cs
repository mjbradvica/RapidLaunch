// <copyright file="RapidLaunchPublisherTests.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        public async Task PublishDomainEvent_PublishesEvents()
        {
            var handler = new Mock<IDomainEventHandler<TestNotification>>();
            handler.Setup(x => x.HandleDomainEvent(It.IsAny<TestNotification>(), CancellationToken.None))
                .Returns(Task.CompletedTask);

            var collection = new ServiceCollection();

            collection.AddTransient(_ => handler.Object);

            var provider = collection.BuildServiceProvider();

            var publisher = new RapidLaunchPublisher(provider);

            await publisher.PublishDomainEvent(new TestNotification());

            handler.Verify(x => x.HandleDomainEvent(It.IsAny<TestNotification>(), CancellationToken.None), Times.Once);
        }
    }
}
