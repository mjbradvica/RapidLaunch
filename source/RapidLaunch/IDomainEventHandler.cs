// <copyright file="IDomainEventHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;

namespace RapidLaunch
{
    /// <summary>
    /// Interface to define a handler class for a domain event.
    /// </summary>
    /// <typeparam name="TDomainEvent">The type of the <see cref="IDomainEvent"/>.</typeparam>
    public interface IDomainEventHandler<in TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
        /// <summary>
        /// Handles a domain event published by a <see cref="IAggregateRoot{T}"/>.
        /// </summary>
        /// <param name="domainEvent">The domain event to be handled.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task HandleDomainEvent(TDomainEvent domainEvent, CancellationToken cancellationToken = default);
    }
}
