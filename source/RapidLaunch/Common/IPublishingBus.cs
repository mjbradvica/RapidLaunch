// <copyright file="IPublishingBus.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace RapidLaunch.Common
{
    /// <summary>
    /// Placeholder interface for a publishing bus.
    /// </summary>
    /// <typeparam name="TDomainEvent">The type of the domain event.</typeparam>
    public interface IPublishingBus<in TDomainEvent>
    {
        /// <summary>
        /// Publishes a domain event to the application.
        /// </summary>
        /// <param name="domainEvent">The event to be published.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task PublishDomainEvent(TDomainEvent domainEvent, CancellationToken cancellationToken = default);
    }
}
