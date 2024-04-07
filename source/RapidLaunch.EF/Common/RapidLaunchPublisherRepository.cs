// <copyright file="RapidLaunchPublisherRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.Common;
using RapidLaunch.EF.Exceptions;

namespace RapidLaunch.EF.Common
{
    /// <summary>
    /// Base publishing repository for EF.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public abstract class RapidLaunchPublisherRepository<TEntity, TId> :
        IAddEntities<TEntity, TId>,
        IAddEntitiesAsync<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        private readonly DbContext _dbContext;
        private readonly IPublishingBus _publishingBus;
        private readonly Func<IQueryable<TEntity>, IQueryable<TEntity>>? _includeFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherRepository{TEntity,TId}"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of the <see cref="DbContext"/> class.</param>
        /// <param name="publishingBus">An instance of the <see cref="IPublishingBus"/> interface.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> that will return a <see cref="IQueryable{T}"/> used to eagerly load related aggregateRoots.</param>
        protected RapidLaunchPublisherRepository(DbContext dbContext, IPublishingBus publishingBus, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeFunc = default)
        {
            _dbContext = dbContext;
            _publishingBus = publishingBus;
            _includeFunc = includeFunc;
        }

        /// <inheritdoc />
        public virtual RapidLaunchStatus AddEntities(IEnumerable<TEntity> entities)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var aggregateRoots = entities.ToList();

                    _dbContext.Set<TEntity>().AddRange(aggregateRoots);

                    var rowCount = _dbContext.SaveChanges();

                    transaction.Commit();

                    PublishDomainEvents(rowCount, aggregateRoots);
                }
                catch (EventPublishingException eventPublishingException)
                {
                    transaction.Rollback();

                    return RapidLaunchStatus.Failed(eventPublishingException);
                }
                catch (Exception exception)
                {
                    transaction.Rollback();

                    return RapidLaunchStatus.Failed(exception);
                }
            }

            return RapidLaunchStatus.Success();
        }

        /// <inheritdoc />
        public virtual async Task<int> AddEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            var aggregateRoots = entities.ToList();

            await _dbContext.Set<TEntity>().AddRangeAsync(aggregateRoots, cancellationToken);

            var rowCount = await _dbContext.SaveChangesAsync(cancellationToken);

            await PublishDomainEventsAsync(rowCount, aggregateRoots, cancellationToken);

            return rowCount;
        }

        /// <summary>
        /// Publishes all events for a <see cref="IAggregateRoot{TId}"/>.
        /// </summary>
        /// <param name="rowCount">The number of rows touched by the operation.</param>
        /// <param name="aggregateRoots">A <see cref="IEnumerable{T}"/> of <see cref="IAggregateRoot{TId}"/> to publish events from.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected virtual async Task PublishDomainEventsAsync(int rowCount, IEnumerable<TEntity> aggregateRoots, CancellationToken cancellationToken)
        {
            IDomainEvent currentEvent = new EmptyDomainEvent();

            try
            {
                const int zeroRowsAffected = 0;

                if (rowCount > zeroRowsAffected)
                {
                    foreach (var aggregateRoot in aggregateRoots)
                    {
                        foreach (var domainEvent in aggregateRoot.DomainEvents)
                        {
                            currentEvent = domainEvent;

                            await _publishingBus.PublishDomainEvent(domainEvent, CancellationToken.None);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new EventPublishingException(exception, currentEvent);
            }
        }

        /// <summary>
        /// Publishes all events for a <see cref="IAggregateRoot{TId}"/>.
        /// </summary>
        /// <param name="rowCount">The number of rows touched by the operation.</param>
        /// <param name="aggregateRoots">A <see cref="IEnumerable{T}"/> of <see cref="IAggregateRoot{TId}"/> to publish events from.</param>
        protected virtual void PublishDomainEvents(int rowCount, IEnumerable<TEntity> aggregateRoots)
        {
            const int zeroRowsAffected = 0;

            if (rowCount > zeroRowsAffected)
            {
                foreach (var aggregateRoot in aggregateRoots)
                {
                    foreach (var domainEvent in aggregateRoot.DomainEvents)
                    {
                        _publishingBus.PublishDomainEvent(domainEvent, CancellationToken.None).RunSynchronously();
                    }
                }
            }
        }

        private IQueryable<TEntity> IncludedContext()
        {
            return _includeFunc == null ? _dbContext.Set<TEntity>() : _includeFunc.Invoke(_dbContext.Set<TEntity>());
        }
    }
}
