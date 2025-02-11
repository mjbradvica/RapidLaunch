// <copyright file="RapidLaunchPublisher.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;
using Microsoft.Extensions.DependencyInjection;

namespace RapidLaunch.Common
{
    /// <summary>
    /// Default publisher for RapidLaunch.
    /// </summary>
    public sealed class RapidLaunchPublisher : IPublishingBus
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisher"/> class.
        /// </summary>
        /// <param name="serviceProvider">An instance of the <see cref="IServiceProvider"/> interface.</param>
        public RapidLaunchPublisher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        public async Task PublishDomainEvent<TDomainEvent>(TDomainEvent domainEvent, CancellationToken cancellationToken = default)
            where TDomainEvent : IDomainEvent
        {
            var services = _serviceProvider.GetServices<IDomainEventHandler<TDomainEvent>>();

            foreach (var eventHandler in services)
            {
                await eventHandler.HandleDomainEvent(domainEvent, cancellationToken);
            }
        }
    }
}
