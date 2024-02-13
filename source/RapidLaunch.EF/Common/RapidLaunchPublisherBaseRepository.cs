// <copyright file="RapidLaunchPublisherBaseRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RapidLaunch.Common;

namespace RapidLaunch.EF.Common
{
    /// <summary>
    /// Base publishing repository for EF.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public abstract class RapidLaunchPublisherBaseRepository<TEntity, TId> : IAddEntitiesAsync<TEntity, TId>
        where TEntity : IAggregateRoot<TId>
    {
        private readonly IPublishingBus _publishingBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherBaseRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="publishingBus">An instance of the <see cref="IPublishingBus"/> interface.</param>
        protected RapidLaunchPublisherBaseRepository(IPublishingBus publishingBus)
        {
            _publishingBus = publishingBus;
        }

        /// <inheritdoc />
        public virtual async Task<int> AddEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            foreach (var aggregateRoot in entities)
            {
                await PublishDomainEvents(aggregateRoot, cancellationToken);
            }

            return 0;
        }

        /// <summary>
        /// Publishes all events for a <see cref="IAggregateRoot{TId}"/>.
        /// </summary>
        /// <param name="aggregateRoot">An aggregate root to publish events from.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected virtual async Task PublishDomainEvents(IAggregateRoot<TId> aggregateRoot, CancellationToken cancellationToken)
        {
            foreach (var domainEvent in aggregateRoot.DomainEvents)
            {
                await _publishingBus.PublishDomainEvent(domainEvent, cancellationToken);
            }
        }
    }
}
