// <copyright file="RapidLaunchPublisherBaseRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.Common;

namespace RapidLaunch.EF.Common
{
    /// <summary>
    /// Base publishing repository for EF.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public abstract class RapidLaunchPublisherBaseRepository<TEntity, TId> : IAddEntitiesAsync<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        private readonly DbContext _dbContext;
        private readonly IPublishingBus _publishingBus;
        private readonly Func<IQueryable<TEntity>, IQueryable<TEntity>>? _includeFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherBaseRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of the <see cref="DbContext"/> class.</param>
        /// <param name="publishingBus">An instance of the <see cref="IPublishingBus"/> interface.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> that will return a <see cref="IQueryable{T}"/> used to eagerly load related entities.</param>
        protected RapidLaunchPublisherBaseRepository(DbContext dbContext, IPublishingBus publishingBus, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeFunc = default)
        {
            _dbContext = dbContext;
            _publishingBus = publishingBus;
            _includeFunc = includeFunc;
        }

        /// <inheritdoc />
        public virtual async Task<int> AddEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            int rowCount;

            try
            {
                var aggregateRoots = entities.ToList();

                await _dbContext.Set<TEntity>().AddRangeAsync(aggregateRoots, cancellationToken);

                rowCount = await _dbContext.SaveChangesAsync(cancellationToken);

                if (rowCount > 0)
                {
                    foreach (var aggregateRoot in aggregateRoots)
                    {
                        await PublishDomainEvents(aggregateRoot, cancellationToken);
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }

            return rowCount;
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

        private IQueryable<TEntity> IncludedContext()
        {
            return _includeFunc == null ? _dbContext.Set<TEntity>() : _includeFunc.Invoke(_dbContext.Set<TEntity>());
        }
    }
}
