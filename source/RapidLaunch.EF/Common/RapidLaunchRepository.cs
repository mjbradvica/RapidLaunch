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
    /// Common functions for all EF RapidLaunch repositories.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public abstract class RapidLaunchRepository<TEntity, TId> :
        IAddEntities<TEntity, TId>,
        IAddEntitiesAsync<TEntity, TId>,
        IAddEntity<TEntity, TId>,
        IAddEntityAsync<TEntity, TId>,
        IDeleteEntities<TEntity, TId>,
        IDeleteEntitiesAsync<TEntity, TId>,
        IDeleteEntity<TEntity, TId>,
        IDeleteEntityAsync<TEntity, TId>,
        IGetAllEntities<TEntity, TId>,
        IGetAllEntitiesAsync<TEntity, TId>,
        IGetAllEntitiesLazy<TEntity, TId>,
        IGetById<TEntity, TId>,
        IGetByIdAsync<TEntity, TId>,
        ISearchEntities<TEntity, TId>,
        ISearchEntitiesAsync<TEntity, TId>,
        ISearchEntitiesLazy<TEntity, TId>,
        IUpdateEntities<TEntity, TId>,
        IUpdateEntitiesAsync<TEntity, TId>,
        IUpdateEntity<TEntity, TId>,
        IUpdateEntityAsync<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        private readonly Func<IQueryable<TEntity>, IQueryable<TEntity>>? _includeFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TEntity,TId}"/> class.
        /// </summary>
        /// <param name="context">An instance of the <see cref="DbContext"/> class.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> that will return a <see cref="IQueryable{T}"/> used to eagerly load related aggregateRoots.</param>
        protected RapidLaunchRepository(DbContext context, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeFunc = default)
        {
            Context = context;
            _includeFunc = includeFunc;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TEntity,TId}"/> class.
        /// </summary>
        /// <param name="context">An instance of the <see cref="DbContext"/> class.</param>
        protected RapidLaunchRepository(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Gets the Context.
        /// </summary>
        protected DbContext Context { get; }

        /// <inheritdoc />
        public virtual RapidLaunchStatus AddEntities(IEnumerable<TEntity> entities)
        {
            return ExecuteCommand(() =>
            {
                var aggregateRoots = entities.ToList();

                Context.Set<TEntity>().AddRange(aggregateRoots);

                var rowCount = Context.SaveChanges();

                return (rowCount, aggregateRoots);
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> AddEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
                {
                    var aggregateRoots = entities.ToList();

                    await Context.Set<TEntity>().AddRangeAsync(aggregateRoots, cancellationToken);

                    var rowCount = await Context.SaveChangesAsync(cancellationToken);

                    return (rowCount, aggregateRoots);
                },
                cancellationToken);
        }

        /// <inheritdoc/>
        public virtual RapidLaunchStatus AddEntity(TEntity entity)
        {
            return ExecuteCommand(() =>
            {
                Context.Set<TEntity>().Add(entity);

                var rowCount = Context.SaveChanges();

                return (rowCount, new List<TEntity> { entity });
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> AddEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
                {
                    await Context.Set<TEntity>().AddAsync(entity, cancellationToken);

                    var rowCount = await Context.SaveChangesAsync(cancellationToken);

                    return (rowCount, new List<TEntity> { entity });
                },
                cancellationToken);
        }

        /// <inheritdoc/>
        public virtual RapidLaunchStatus DeleteEntities(IEnumerable<TEntity> entities)
        {
            return ExecuteCommand(() =>
            {
                var aggregateRoots = entities.ToList();

                Context.Set<TEntity>().RemoveRange(aggregateRoots);

                var rowCount = Context.SaveChanges();

                return (rowCount, aggregateRoots);
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> DeleteEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
            {
                var aggregateRoots = entities.ToList();

                Context.Set<TEntity>().RemoveRange(aggregateRoots);

                var rowCount = await Context.SaveChangesAsync(cancellationToken);

                return (rowCount, aggregateRoots);
            },
                cancellationToken);
        }

        /// <inheritdoc/>
        public virtual RapidLaunchStatus DeleteEntity(TEntity entity)
        {
            return ExecuteCommand(() =>
            {
                Context.Set<TEntity>().Remove(entity);

                var rowCount = Context.SaveChanges();

                return (rowCount, new List<TEntity> { entity });
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> DeleteEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
                {
                    Context.Set<TEntity>().Remove(entity);

                    var rowCount = await Context.SaveChangesAsync(cancellationToken);

                    return (rowCount, new List<TEntity> { entity });
                },
                cancellationToken);
        }

        /// <inheritdoc/>
        public virtual List<TEntity> GetAllEntities()
        {
            return ExecuteQuery(queryable => queryable).ToList();
        }

        /// <summary>
        /// Retrieves all entities from a table with an include override.
        /// </summary>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <returns>A <see cref="List{T}"/> of entities.</returns>
        public virtual List<TEntity> GetAllEntities(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            return ExecuteQuery(queryable => queryable, includeFunc).ToList();
        }

        /// <inheritdoc/>
        public virtual async Task<List<TEntity>> GetAllEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(queryable => queryable.ToListAsync(cancellationToken));
        }

        /// <summary>
        /// Retrieves all entities from a table with an include override.
        /// </summary>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="List{T}"/> representing the asynchronous operation.</returns>
        public virtual async Task<List<TEntity>> GetAllEntitiesAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(queryable => queryable.ToListAsync(cancellationToken), includeFunc);
        }

        /// <inheritdoc/>
        public virtual IQueryable<TEntity> GetAllEntitiesLazy()
        {
            return ExecuteQuery(queryable => queryable);
        }

        /// <summary>
        /// Retrieves all entities from a table lazily with an include override.
        /// </summary>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <returns>A <see cref="IQueryable{T}"/> of entities that may be further queried against.</returns>
        public virtual IQueryable<TEntity> GetAllEntitiesLazy(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            return ExecuteQuery(queryable => queryable, includeFunc);
        }

        /// <inheritdoc/>
        public virtual TEntity? GetById(TId id)
        {
            return ExecuteQuery(queryable => queryable).FirstOrDefault(entity => entity.Id!.Equals(id));
        }

        /// <summary>
        /// Retrieves an entity by an identifier with an include override.
        /// </summary>
        /// <param name="id">The identifier for the entity.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <returns>A nullable entity.</returns>
        public virtual TEntity? GetById(TId id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            return ExecuteQuery(queryable => queryable, includeFunc).FirstOrDefault(entity => entity.Id!.Equals(id));
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return await ExecuteQuery(queryable => queryable)
                .FirstOrDefaultAsync(entity => entity.Id!.Equals(id), cancellationToken);
        }

        /// <summary>
        /// Retrieves an entity by an identifier with an include override.
        /// </summary>
        /// <param name="id">The identifier for the entity.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of nullable entity representing the asynchronous operation.</returns>
        public virtual async Task<TEntity?> GetByIdAsync(TId id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await ExecuteQuery(queryable => queryable, includeFunc)
                .FirstOrDefaultAsync(entity => entity.Id!.Equals(id), cancellationToken);
        }

        /// <inheritdoc/>
        public virtual List<TEntity> SearchEntities(IQuery<TEntity> queryObject)
        {
            return ExecuteQuery(queryable => queryable.Where(queryObject.SearchExpression)).ToList();
        }

        /// <summary>
        /// Searches all entities that satisfy a <see cref="IQuery{TEntity}"/>.
        /// </summary>
        /// <param name="queryObject">An instance of a <see cref="IQuery{TEntity}"/>.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <returns>A <see cref="List{T}"/> of entities that satisfy the query.</returns>
        public virtual List<TEntity> SearchEntities(IQuery<TEntity> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            return ExecuteQuery(queryable => queryable.Where(queryObject.SearchExpression), includeFunc).ToList();
        }

        /// <inheritdoc/>
        public virtual async Task<List<TEntity>> SearchEntitiesAsync(IQuery<TEntity> queryObject, CancellationToken cancellationToken)
        {
            return await ExecuteQueryAsync(queryable => queryable.Where(queryObject.SearchExpression).ToListAsync(cancellationToken));
        }

        /// <summary>
        /// Searches all entities that satisfy a <see cref="IQuery{TEntity}"/>.
        /// </summary>
        /// <param name="queryObject">An instance of a <see cref="IQuery{TEntity}"/>.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="List{T}"/> representing the asynchronous operation.</returns>
        public virtual async Task<List<TEntity>> SearchEntitiesAsync(IQuery<TEntity> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(queryable => queryable.Where(queryObject.SearchExpression).ToListAsync(cancellationToken), includeFunc);
        }

        /// <inheritdoc/>
        public virtual IQueryable<TEntity> SearchEntitiesLazy(IQuery<TEntity> queryObject)
        {
            return ExecuteQuery(queryable => queryable.Where(queryObject.SearchExpression));
        }

        /// <summary>
        /// Searches all entities that satisfy a <see cref="IQuery{TEntity}"/> and allows for further filtering.
        /// </summary>
        /// <param name="queryObject">An instance of a <see cref="IQuery{TEntity}"/>.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <returns>A <see cref="IQueryable{T}"/>.</returns>
        public virtual IQueryable<TEntity> SearchEntitiesLazy(IQuery<TEntity> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            return ExecuteQuery(queryable => queryable.Where(queryObject.SearchExpression), includeFunc);
        }

        /// <inheritdoc/>
        public virtual RapidLaunchStatus UpdateEntities(IEnumerable<TEntity> entities)
        {
            return ExecuteCommand(() =>
            {
                var aggregateRoots = entities.ToList();

                Context.Set<TEntity>().UpdateRange(aggregateRoots);

                var rowCount = Context.SaveChanges();

                return (rowCount, aggregateRoots);
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> UpdateEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
            {
                var aggregateRoots = entities.ToList();

                Context.Set<TEntity>().UpdateRange(aggregateRoots);

                var rowCount = await Context.SaveChangesAsync(cancellationToken);

                return (rowCount, aggregateRoots);
            },
                cancellationToken);
        }

        /// <inheritdoc/>
        public virtual RapidLaunchStatus UpdateEntity(TEntity entity)
        {
            return ExecuteCommand(() =>
            {
                Context.Set<TEntity>().Update(entity);

                var rowCount = Context.SaveChanges();

                return (rowCount, new List<TEntity> { entity });
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> UpdateEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
                {
                    Context.Set<TEntity>().Update(entity);

                    var rowCount = await Context.SaveChangesAsync(cancellationToken);

                    return (rowCount, new List<TEntity> { entity });
                },
                cancellationToken);
        }

        /// <summary>
        /// Executes a command against the persistence.
        /// </summary>
        /// <param name="executionFunc">A <see cref="Func{TResult}"/> that contains an operation to execute.</param>
        /// <param name="postOperationFunc">A <see cref="Func{TResult}"/> to run post operation effects.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> indicating the status of the operation.</returns>
        protected virtual RapidLaunchStatus ExecuteCommand(Func<(int RowCount, IEnumerable<TEntity> Entities)> executionFunc, Func<int, IEnumerable<IAggregateRoot<TId>>, Task>? postOperationFunc = default)
        {
            int rowsAffected;

            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    var (rowCount, aggregateRoots) = executionFunc.Invoke();

                    rowsAffected = rowCount;

                    postOperationFunc?.Invoke(rowsAffected, aggregateRoots).RunSynchronously();

                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    transaction.Rollback();

                    return RapidLaunchStatus.Failed(exception);
                }
            }

            return RapidLaunchStatus.Success(rowsAffected);
        }

        /// <summary>
        /// Executes a command against the persistence.
        /// </summary>
        /// <param name="executionFunc">A <see cref="Func{TResult}"/> that contains an operation to execute.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <param name="postOperationFunc">A <see cref="Func{TResult}"/> to run post operation effects.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected virtual async Task<RapidLaunchStatus> ExecuteCommandAsync(Func<Task<(int RowCount, IEnumerable<TEntity> Entities)>> executionFunc, CancellationToken cancellationToken, Func<int, IEnumerable<IAggregateRoot<TId>>, Task>? postOperationFunc = default)
        {
            int rowsAffected;

            await using (var transaction = await Context.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var (rowCount, aggregateRoots) = await executionFunc.Invoke();

                    rowsAffected = rowCount;

                    if (postOperationFunc != null)
                    {
                        await postOperationFunc.Invoke(rowsAffected, aggregateRoots);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }
                catch (Exception exception)
                {
                    await transaction.RollbackAsync(cancellationToken);

                    return RapidLaunchStatus.Failed(exception);
                }
            }

            return RapidLaunchStatus.Success(rowsAffected);
        }

        /// <summary>
        /// Executes a query against the persistence.
        /// </summary>
        /// <param name="query">A <see cref="Func{TResult}"/> that contains the query.</param>
        /// <param name="overrideFunc">A <see cref="Func{TResult}"/> that may override the default include statement.</param>
        /// <returns>A <see cref="List{T}"/> from the query operation.</returns>
        protected virtual IQueryable<TEntity> ExecuteQuery(Func<IQueryable<TEntity>, IQueryable<TEntity>> query, Func<IQueryable<TEntity>, IQueryable<TEntity>>? overrideFunc = default)
        {
            var includeFunc = _includeFunc ?? overrideFunc;

            var queryable = Context.Set<TEntity>();

            var afterInclude = includeFunc?.Invoke(queryable);

            return afterInclude != null ? query.Invoke(afterInclude) : query.Invoke(queryable);
        }

        /// <summary>
        /// Executes a query against the persistence.
        /// </summary>
        /// <param name="query">A <see cref="Func{TResult}"/> that contains the query.</param>
        /// <param name="overrideFunc">A <see cref="Func{TResult}"/> that may override the default include statement.</param>
        /// <returns>A <see cref="Task"/> of <see cref="List{T}"/> from the query operation.</returns>
        protected virtual async Task<List<TEntity>> ExecuteQueryAsync(Func<IQueryable<TEntity>, Task<List<TEntity>>> query, Func<IQueryable<TEntity>, IQueryable<TEntity>>? overrideFunc = default)
        {
            var includeFunc = _includeFunc ?? overrideFunc;

            var queryable = Context.Set<TEntity>();

            var afterInclude = includeFunc?.Invoke(queryable);

            return afterInclude != null ? await query.Invoke(afterInclude) : await query.Invoke(queryable);
        }
    }
}
