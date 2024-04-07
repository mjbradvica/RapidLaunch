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
        IAddEntitiesAsync<TEntity, TId>,
        IAddEntity<TEntity, TId>,
        IAddEntityAsync<TEntity, TId>
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
            return ExecuteOperation(() =>
            {
                var aggregateRoots = entities.ToList();

                _dbContext.Set<TEntity>().AddRange(aggregateRoots);

                var rowCount = _dbContext.SaveChanges();

                return (rowCount, aggregateRoots);
            });
        }

        /// <inheritdoc />
        public virtual async Task<RapidLaunchStatus> AddEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return await ExecuteOperationAsync(
                async () =>
            {
                var aggregateRoots = entities.ToList();

                await _dbContext.Set<TEntity>().AddRangeAsync(aggregateRoots, cancellationToken);

                var rowCount = await _dbContext.SaveChangesAsync(cancellationToken);

                return (rowCount, aggregateRoots);
            },
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual RapidLaunchStatus AddEntity(TEntity entity)
        {
            return ExecuteOperation(() =>
            {
                _dbContext.Set<TEntity>().Add(entity);

                var rowCount = _dbContext.SaveChanges();

                return (rowCount, new List<TEntity> { entity });
            });
        }

        /// <inheritdoc />
        public virtual async Task<RapidLaunchStatus> AddEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return await ExecuteOperationAsync(
                async () =>
            {
                await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

                var rowCount = await _dbContext.SaveChangesAsync(cancellationToken);

                return (rowCount, new List<TEntity> { entity });
            },
                cancellationToken);
        }

        /// <summary>
        /// Publishes all events for a <see cref="IAggregateRoot{TId}"/>.
        /// </summary>
        /// <param name="executionFunc">A <see cref="Func{TResult}"/> that contains an operation to execute.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public virtual async Task<RapidLaunchStatus> ExecuteOperationAsync(Func<Task<(int RowCount, IEnumerable<TEntity> Entities)>> executionFunc, CancellationToken cancellationToken)
        {
            IDomainEvent currentEvent = new EmptyDomainEvent();

            await using (var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var (rowCount, aggregateRoots) = await executionFunc.Invoke();

                    const int zeroRowsAffected = 0;

                    try
                    {
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
                catch (EventPublishingException eventPublishingException)
                {
                    await transaction.RollbackAsync(cancellationToken);

                    return RapidLaunchStatus.Failed(eventPublishingException);
                }
                catch (Exception exception)
                {
                    await transaction.RollbackAsync(cancellationToken);

                    return RapidLaunchStatus.Failed(exception);
                }
            }

            return RapidLaunchStatus.Success();
        }

        /// <summary>
        /// Publishes all events for a <see cref="IAggregateRoot{TId}"/>.
        /// </summary>
        /// <param name="executionFunc">A <see cref="Func{TResult}"/> that contains an operation to execute.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> indicating the status of the operation.</returns>
        protected virtual RapidLaunchStatus ExecuteOperation(Func<(int RowCount, IEnumerable<TEntity> Entities)> executionFunc)
        {
            IDomainEvent currentEvent = new EmptyDomainEvent();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var (rowCount, aggregateRoots) = executionFunc.Invoke();

                    const int zeroRowsAffected = 0;

                    try
                    {
                        if (rowCount > zeroRowsAffected)
                        {
                            foreach (var aggregateRoot in aggregateRoots)
                            {
                                foreach (var domainEvent in aggregateRoot.DomainEvents)
                                {
                                    currentEvent = domainEvent;

                                    _publishingBus.PublishDomainEvent(domainEvent, CancellationToken.None).RunSynchronously();
                                }
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new EventPublishingException(exception, currentEvent);
                    }
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

        private IQueryable<TEntity> IncludedContext()
        {
            return _includeFunc == null ? _dbContext.Set<TEntity>() : _includeFunc.Invoke(_dbContext.Set<TEntity>());
        }
    }
}
