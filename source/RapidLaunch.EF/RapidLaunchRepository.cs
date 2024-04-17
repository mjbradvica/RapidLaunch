// <copyright file="RapidLaunchRepository.cs" company="Michael Bradvica LLC">
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

namespace RapidLaunch.EF
{
    /// <summary>
    /// Base repository for EF.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public abstract class RapidLaunchRepository<TEntity, TId> :
        IAddEntitiesAsync<TEntity, TId>,
        IGetByIdAsync<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        private readonly Func<IQueryable<TEntity>, IQueryable<TEntity>>? _includeFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TEntity,TId}"/> class.
        /// </summary>
        /// <param name="dbContext">An instance of the <see cref="DbContext"/> class.</param>
        /// <param name="includeFunc">Optional include <see cref="Func{TResult}"/> for eager loading.</param>
        protected RapidLaunchRepository(DbContext dbContext, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeFunc = default)
        {
            DbContext = dbContext;
            _includeFunc = includeFunc;
        }

        /// <summary>
        /// Gets the DbContext class.
        /// </summary>
        protected DbContext DbContext { get; }

        /// <inheritdoc />
        public virtual async Task<RapidLaunchStatus> AddEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
                {
                    await DbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);

                    return await DbContext.SaveChangesAsync(cancellationToken);
                });
        }

        /// <inheritdoc />
        public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return await ExecuteQuery(query => query.Where(entity => entity.Id!.Equals(id))).FirstOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves an <see cref="IEntity{T}"/> by an identifier with an overload for loading related entities.
        /// </summary>
        /// <param name="id">The identifier for the entity.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to include navigation properties.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public virtual async Task<TEntity?> GetByIdAsync(TId id, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeFunc, CancellationToken cancellationToken = default)
        {
            return await ExecuteQuery(query => query.Where(entity => entity.Id!.Equals(id)), includeFunc).FirstOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// Publishes all events for a <see cref="IAggregateRoot{TId}"/>.
        /// </summary>
        /// <param name="executionFunc">A <see cref="Func{TResult}"/> that contains an operation to execute.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task<RapidLaunchStatus> ExecuteCommandAsync(Func<Task<int>> executionFunc)
        {
            int rowCount;

            try
            {
                rowCount = await executionFunc.Invoke();
            }
            catch (Exception exception)
            {
                return RapidLaunchStatus.Failed(exception);
            }

            return RapidLaunchStatus.Success(rowCount);
        }

        /// <summary>
        /// Executes a query against the persistence.
        /// </summary>
        /// <param name="query">A <see cref="Func{TResult}"/> that contains the query.</param>
        /// <param name="overrideFunc">A <see cref="Func{TResult}"/> that may override the default include statement.</param>
        /// <returns>A <see cref="List{T}"/> from the query operation.</returns>
        protected IQueryable<TEntity> ExecuteQuery(Func<IQueryable<TEntity>, IQueryable<TEntity>> query, Func<IQueryable<TEntity>, IQueryable<TEntity>>? overrideFunc = default)
        {
            var includeFunc = _includeFunc ?? overrideFunc;

            IQueryable<TEntity> queryable = DbContext.Set<TEntity>();

            includeFunc?.Invoke(DbContext.Set<TEntity>());

            return query.Invoke(queryable);
        }
    }
}
