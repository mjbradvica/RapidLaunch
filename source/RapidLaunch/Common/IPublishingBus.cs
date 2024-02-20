// <copyright file="IPublishingBus.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// Placeholder interface for a publishing bus.
    /// </summary>
    public interface IPublishingBus
    {
        /// <summary>
        /// Publishes a domain event to the application.
        /// </summary>
        /// <param name="domainEvent">The <see cref="IDomainEvent"/> to be published.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task PublishDomainEvent(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
    }
}
