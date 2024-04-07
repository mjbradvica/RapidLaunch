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

namespace RapidLaunch.EF.Common
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
        public virtual async Task<int> AddEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await DbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);

            return await DbContext.SaveChangesAsync(cancellationToken);
        }

        /// <inheritdoc />
        public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return await EntityContext().FirstOrDefaultAsync(entity => entity.Id!.Equals(id), cancellationToken);
        }

        private IQueryable<TEntity> EntityContext()
        {
            return _includeFunc == null ? DbContext.Set<TEntity>() : _includeFunc.Invoke(DbContext.Set<TEntity>());
        }
    }
}
