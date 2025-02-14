// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

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
        IAddRoots<TEntity, TId>,
        IAddRootsAsync<TEntity, TId>,
        IAddRoot<TEntity, TId>,
        IAddRootAsync<TEntity, TId>,
        IDeleteRoots<TEntity, TId>,
        IDeleteRootsAsync<TEntity, TId>,
        IDeleteRoot<TEntity, TId>,
        IDeleteRootAsync<TEntity, TId>,
        IGetAllRoots<TEntity, TId>,
        IGetAllRootsAsync<TEntity, TId>,
        IGetAllEntitiesLazy<TEntity, TId>,
        IGetRootById<TEntity, TId>,
        IGetByIdAsync<TEntity, TId>,
        IGetRootsById<TEntity, TId>,
        IGetRootsByIdAsync<TEntity, TId>,
        ISearchRoots<TEntity, TId>,
        ISearchRootsAsync<TEntity, TId>,
        ISearchRootsLazy<TEntity, TId>,
        IUpdateRoots<TEntity, TId>,
        IUpdateRootsAsync<TEntity, TId>,
        IUpdateRoot<TEntity, TId>,
        IUpdateRootAsync<TEntity, TId>
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
        public virtual RapidLaunchStatus AddRoots(IEnumerable<TEntity> roots)
        {
            return ExecuteCommand(() =>
            {
                var aggregateRoots = roots.ToList();

                Context.Set<TEntity>().AddRange(aggregateRoots);

                var rowCount = Context.SaveChanges();

                return (rowCount, aggregateRoots);
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> AddRootsAsync(IEnumerable<TEntity> roots, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
                {
                    var aggregateRoots = roots.ToList();

                    await Context.Set<TEntity>().AddRangeAsync(aggregateRoots, cancellationToken);

                    var rowCount = await Context.SaveChangesAsync(cancellationToken);

                    return (rowCount, aggregateRoots);
                },
                cancellationToken);
        }

        /// <inheritdoc/>
        public virtual RapidLaunchStatus AddRoot(TEntity root)
        {
            return ExecuteCommand(() =>
            {
                Context.Set<TEntity>().Add(root);

                var rowCount = Context.SaveChanges();

                return (rowCount, new List<TEntity> { root });
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> AddRootAsync(TEntity root, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
                {
                    await Context.Set<TEntity>().AddAsync(root, cancellationToken);

                    var rowCount = await Context.SaveChangesAsync(cancellationToken);

                    return (rowCount, new List<TEntity> { root });
                },
                cancellationToken);
        }

        /// <inheritdoc/>
        public virtual RapidLaunchStatus DeleteRoots(IEnumerable<TEntity> roots)
        {
            return ExecuteCommand(() =>
            {
                var aggregateRoots = roots.ToList();

                Context.Set<TEntity>().RemoveRange(aggregateRoots);

                var rowCount = Context.SaveChanges();

                return (rowCount, aggregateRoots);
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> DeleteRootsAsync(IEnumerable<TEntity> roots, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
            {
                var aggregateRoots = roots.ToList();

                Context.Set<TEntity>().RemoveRange(aggregateRoots);

                var rowCount = await Context.SaveChangesAsync(cancellationToken);

                return (rowCount, aggregateRoots);
            },
                cancellationToken);
        }

        /// <inheritdoc/>
        public virtual RapidLaunchStatus DeleteRoot(TEntity root)
        {
            return ExecuteCommand(() =>
            {
                Context.Set<TEntity>().Remove(root);

                var rowCount = Context.SaveChanges();

                return (rowCount, new List<TEntity> { root });
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> DeleteRootAsync(TEntity root, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
                {
                    Context.Set<TEntity>().Remove(root);

                    var rowCount = await Context.SaveChangesAsync(cancellationToken);

                    return (rowCount, new List<TEntity> { root });
                },
                cancellationToken);
        }

        /// <inheritdoc/>
        public virtual List<TEntity> GetAllRoots()
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
        public virtual async Task<List<TEntity>> GetAllRootsAsync(CancellationToken cancellationToken = default)
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

        /// <inheritdoc />
        public virtual List<TEntity> GetRootsById(IEnumerable<TId> identifiers)
        {
            return ExecuteQuery(queryable => queryable.Where(entity => identifiers.Contains(entity.Id))).ToList();
        }

        /// <summary>
        /// Retrieves a list of entities that match a parameter of identifiers.
        /// </summary>
        /// <param name="identifiers">A <see cref="IEnumerable{T}"/> of identifiers.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <returns>A <see cref="List{T}"/> of entities.</returns>
        public virtual List<TEntity> GetEntitiesById(IEnumerable<TId> identifiers, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            return ExecuteQuery(queryable => queryable.Where(entity => identifiers.Contains(entity.Id)), includeFunc).ToList();
        }

        /// <inheritdoc/>
        public virtual async Task<List<TEntity>> GetRootsByIdAsync(IEnumerable<TId> identifiers, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(queryable => queryable.Where(entity => identifiers.Contains(entity.Id)).ToListAsync(cancellationToken));
        }

        /// <summary>
        /// Retrieves an entity by an identifier with an include override.
        /// </summary>
        /// <param name="identifiers">A <see cref="IEnumerable{T}"/> of identifiers.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public virtual async Task<List<TEntity>> GetEntitiesByIdAsync(IEnumerable<TId> identifiers, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(queryable => queryable.Where(entity => identifiers.Contains(entity.Id)).ToListAsync(cancellationToken), includeFunc);
        }

        /// <inheritdoc/>
        public virtual List<TEntity> SearchRoots(IQuery<TEntity> queryObject)
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
        public virtual async Task<List<TEntity>> SearchRootsAsync(IQuery<TEntity> queryObject, CancellationToken cancellationToken = default)
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
        public virtual IQueryable<TEntity> SearchRootsLazy(IQuery<TEntity> queryObject)
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
        public virtual RapidLaunchStatus UpdateRoots(IEnumerable<TEntity> roots)
        {
            return ExecuteCommand(() =>
            {
                var aggregateRoots = roots.ToList();

                Context.Set<TEntity>().UpdateRange(aggregateRoots);

                var rowCount = Context.SaveChanges();

                return (rowCount, aggregateRoots);
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> UpdateRootsAsync(IEnumerable<TEntity> roots, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
            {
                var aggregateRoots = roots.ToList();

                Context.Set<TEntity>().UpdateRange(aggregateRoots);

                var rowCount = await Context.SaveChangesAsync(cancellationToken);

                return (rowCount, aggregateRoots);
            },
                cancellationToken);
        }

        /// <inheritdoc/>
        public virtual RapidLaunchStatus UpdateRoot(TEntity root)
        {
            return ExecuteCommand(() =>
            {
                Context.Set<TEntity>().Update(root);

                var rowCount = Context.SaveChanges();

                return (rowCount, new List<TEntity> { root });
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> UpdateRootAsync(TEntity root, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
                {
                    Context.Set<TEntity>().Update(root);

                    var rowCount = await Context.SaveChangesAsync(cancellationToken);

                    return (rowCount, new List<TEntity> { root });
                },
                cancellationToken);
        }

        /// <summary>
        /// Executes a command against the persistence.
        /// </summary>
        /// <param name="executionFunc">A <see cref="Func{TResult}"/> that contains an operation to execute.</param>
        /// <param name="postOperationFunc">A <see cref="Func{TResult}"/> to run post operation effects.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> indicating the status of the operation.</returns>
        protected virtual RapidLaunchStatus ExecuteCommand(Func<(int RowCount, IEnumerable<TEntity> Entities)> executionFunc, Action<int, IEnumerable<IAggregateRoot<TId>>>? postOperationFunc = default)
        {
            int rowsAffected;

            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    var (rowCount, aggregateRoots) = executionFunc.Invoke();

                    rowsAffected = rowCount;

                    postOperationFunc?.Invoke(rowsAffected, aggregateRoots);

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
