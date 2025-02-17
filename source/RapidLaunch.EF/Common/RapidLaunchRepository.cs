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
    /// <typeparam name="TRoot">The type of the root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public abstract class RapidLaunchRepository<TRoot, TId> :
        IAddRoots<TRoot, TId>,
        IAddRootsAsync<TRoot, TId>,
        IAddRoot<TRoot, TId>,
        IAddRootAsync<TRoot, TId>,
        IDeleteRoots<TRoot, TId>,
        IDeleteRootsAsync<TRoot, TId>,
        IDeleteRoot<TRoot, TId>,
        IDeleteRootAsync<TRoot, TId>,
        IGetAllRoots<TRoot, TId>,
        IGetAllRootsAsync<TRoot, TId>,
        IGetAllRootsLazy<TRoot, TId>,
        IGetRootById<TRoot, TId>,
        IGetRootByIdAsync<TRoot, TId>,
        IGetRootsById<TRoot, TId>,
        IGetRootsByIdAsync<TRoot, TId>,
        ISearchRoots<TRoot, TId>,
        ISearchRootsAsync<TRoot, TId>,
        ISearchRootsLazy<TRoot, TId>,
        IUpdateRoots<TRoot, TId>,
        IUpdateRootsAsync<TRoot, TId>,
        IUpdateRoot<TRoot, TId>,
        IUpdateRootAsync<TRoot, TId>
        where TRoot : class, IAggregateRoot<TId>
    {
        private readonly Func<IQueryable<TRoot>, IQueryable<TRoot>>? _includeFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TRoot,TId}"/> class.
        /// </summary>
        /// <param name="context">An instance of the <see cref="DbContext"/> class.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> that will return a <see cref="IQueryable{T}"/> used to eagerly load related aggregateRoots.</param>
        protected RapidLaunchRepository(DbContext context, Func<IQueryable<TRoot>, IQueryable<TRoot>>? includeFunc = null)
        {
            Context = context;
            _includeFunc = includeFunc;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TRoot,TId}"/> class.
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
        public virtual RapidLaunchStatus AddRoots(IEnumerable<TRoot> roots)
        {
            return ExecuteCommand(() =>
            {
                var aggregateRoots = roots.ToList();

                Context.Set<TRoot>().AddRange(aggregateRoots);

                var rowCount = Context.SaveChanges();

                return (rowCount, aggregateRoots);
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> AddRootsAsync(IEnumerable<TRoot> roots, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
                {
                    var aggregateRoots = roots.ToList();

                    await Context.Set<TRoot>().AddRangeAsync(aggregateRoots, cancellationToken);

                    var rowCount = await Context.SaveChangesAsync(cancellationToken);

                    return (rowCount, aggregateRoots);
                },
                cancellationToken);
        }

        /// <inheritdoc/>
        public virtual RapidLaunchStatus AddRoot(TRoot root)
        {
            return ExecuteCommand(() =>
            {
                Context.Set<TRoot>().Add(root);

                var rowCount = Context.SaveChanges();

                return (rowCount, new List<TRoot> { root });
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> AddRootAsync(TRoot root, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
                {
                    await Context.Set<TRoot>().AddAsync(root, cancellationToken);

                    var rowCount = await Context.SaveChangesAsync(cancellationToken);

                    return (rowCount, new List<TRoot> { root });
                },
                cancellationToken);
        }

        /// <inheritdoc/>
        public virtual RapidLaunchStatus DeleteRoots(IEnumerable<TRoot> roots)
        {
            return ExecuteCommand(() =>
            {
                var aggregateRoots = roots.ToList();

                Context.Set<TRoot>().RemoveRange(aggregateRoots);

                var rowCount = Context.SaveChanges();

                return (rowCount, aggregateRoots);
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> DeleteRootsAsync(IEnumerable<TRoot> roots, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
            {
                var aggregateRoots = roots.ToList();

                Context.Set<TRoot>().RemoveRange(aggregateRoots);

                var rowCount = await Context.SaveChangesAsync(cancellationToken);

                return (rowCount, aggregateRoots);
            },
                cancellationToken);
        }

        /// <inheritdoc/>
        public virtual RapidLaunchStatus DeleteRoot(TRoot root)
        {
            return ExecuteCommand(() =>
            {
                Context.Set<TRoot>().Remove(root);

                var rowCount = Context.SaveChanges();

                return (rowCount, new List<TRoot> { root });
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> DeleteRootAsync(TRoot root, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
                {
                    Context.Set<TRoot>().Remove(root);

                    var rowCount = await Context.SaveChangesAsync(cancellationToken);

                    return (rowCount, new List<TRoot> { root });
                },
                cancellationToken);
        }

        /// <inheritdoc/>
        public virtual List<TRoot> GetAllRoots()
        {
            return ExecuteQuery(queryable => queryable).ToList();
        }

        /// <summary>
        /// Retrieves all roots from a table with an include override.
        /// </summary>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <returns>A <see cref="List{T}"/> of roots.</returns>
        public virtual List<TRoot> GetAllEntities(Func<IQueryable<TRoot>, IQueryable<TRoot>> includeFunc)
        {
            return ExecuteQuery(queryable => queryable, includeFunc).ToList();
        }

        /// <inheritdoc/>
        public virtual async Task<List<TRoot>> GetAllRootsAsync(CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(queryable => queryable.ToListAsync(cancellationToken));
        }

        /// <summary>
        /// Retrieves all roots from a table with an include override.
        /// </summary>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="List{T}"/> representing the asynchronous operation.</returns>
        public virtual async Task<List<TRoot>> GetAllEntitiesAsync(Func<IQueryable<TRoot>, IQueryable<TRoot>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(queryable => queryable.ToListAsync(cancellationToken), includeFunc);
        }

        /// <inheritdoc/>
        public virtual IQueryable<TRoot> GetAllRootsLazy()
        {
            return ExecuteQuery(queryable => queryable);
        }

        /// <summary>
        /// Retrieves all roots from a table lazily with an include override.
        /// </summary>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <returns>A <see cref="IQueryable{T}"/> of roots that may be further queried against.</returns>
        public virtual IQueryable<TRoot> GetAllEntitiesLazy(Func<IQueryable<TRoot>, IQueryable<TRoot>> includeFunc)
        {
            return ExecuteQuery(queryable => queryable, includeFunc);
        }

        /// <inheritdoc/>
        public virtual TRoot? GetById(TId id)
        {
            return ExecuteQuery(queryable => queryable).FirstOrDefault(root => root.Id!.Equals(id));
        }

        /// <summary>
        /// Retrieves a root by an identifier with an include override.
        /// </summary>
        /// <param name="id">The identifier for the root.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <returns>A nullable root.</returns>
        public virtual TRoot? GetById(TId id, Func<IQueryable<TRoot>, IQueryable<TRoot>> includeFunc)
        {
            return ExecuteQuery(queryable => queryable, includeFunc).FirstOrDefault(root => root.Id!.Equals(id));
        }

        /// <inheritdoc/>
        public virtual async Task<TRoot?> GetRootByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return await ExecuteQuery(queryable => queryable)
                .FirstOrDefaultAsync(root => root.Id!.Equals(id), cancellationToken);
        }

        /// <summary>
        /// Retrieves a root by an identifier with an include override.
        /// </summary>
        /// <param name="id">The identifier for the root.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of nullable root representing the asynchronous operation.</returns>
        public virtual async Task<TRoot?> GetByIdAsync(TId id, Func<IQueryable<TRoot>, IQueryable<TRoot>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await ExecuteQuery(queryable => queryable, includeFunc)
                .FirstOrDefaultAsync(root => root.Id!.Equals(id), cancellationToken);
        }

        /// <inheritdoc />
        public virtual List<TRoot> GetRootsById(IEnumerable<TId> identifiers)
        {
            return ExecuteQuery(queryable => queryable.Where(root => identifiers.Contains(root.Id))).ToList();
        }

        /// <summary>
        /// Retrieves a list of roots that match a parameter of identifiers.
        /// </summary>
        /// <param name="identifiers">A <see cref="IEnumerable{T}"/> of identifiers.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <returns>A <see cref="List{T}"/> of roots.</returns>
        public virtual List<TRoot> GetEntitiesById(IEnumerable<TId> identifiers, Func<IQueryable<TRoot>, IQueryable<TRoot>> includeFunc)
        {
            return ExecuteQuery(queryable => queryable.Where(root => identifiers.Contains(root.Id)), includeFunc).ToList();
        }

        /// <inheritdoc/>
        public virtual async Task<List<TRoot>> GetRootsByIdAsync(IEnumerable<TId> identifiers, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(queryable => queryable.Where(root => identifiers.Contains(root.Id)).ToListAsync(cancellationToken));
        }

        /// <summary>
        /// Retrieves an root by an identifier with an include override.
        /// </summary>
        /// <param name="identifiers">A <see cref="IEnumerable{T}"/> of identifiers.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public virtual async Task<List<TRoot>> GetEntitiesByIdAsync(IEnumerable<TId> identifiers, Func<IQueryable<TRoot>, IQueryable<TRoot>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(queryable => queryable.Where(root => identifiers.Contains(root.Id)).ToListAsync(cancellationToken), includeFunc);
        }

        /// <inheritdoc/>
        public virtual List<TRoot> SearchRoots(IQuery<TRoot, TId> queryObject)
        {
            return ExecuteQuery(queryable => queryable.Where(queryObject.SearchExpression)).ToList();
        }

        /// <summary>
        /// Searches all roots that satisfy a <see cref="IQuery{TRoot, TId}"/>.
        /// </summary>
        /// <param name="queryObject">An instance of a <see cref="IQuery{TRoot, TId}"/>.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <returns>A <see cref="List{T}"/> of roots that satisfy the query.</returns>
        public virtual List<TRoot> SearchEntities(IQuery<TRoot, TId> queryObject, Func<IQueryable<TRoot>, IQueryable<TRoot>> includeFunc)
        {
            return ExecuteQuery(queryable => queryable.Where(queryObject.SearchExpression), includeFunc).ToList();
        }

        /// <inheritdoc/>
        public virtual async Task<List<TRoot>> SearchRootsAsync(IQuery<TRoot, TId> queryObject, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(queryable => queryable.Where(queryObject.SearchExpression).ToListAsync(cancellationToken));
        }

        /// <summary>
        /// Searches all roots that satisfy a <see cref="IQuery{TRoot, TId}"/>.
        /// </summary>
        /// <param name="queryObject">An instance of a <see cref="IQuery{TRoot, TId}"/>.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="List{T}"/> representing the asynchronous operation.</returns>
        public virtual async Task<List<TRoot>> SearchEntitiesAsync(IQuery<TRoot, TId> queryObject, Func<IQueryable<TRoot>, IQueryable<TRoot>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(queryable => queryable.Where(queryObject.SearchExpression).ToListAsync(cancellationToken), includeFunc);
        }

        /// <inheritdoc/>
        public virtual IQueryable<TRoot> SearchRootsLazy(IQuery<TRoot, TId> queryObject)
        {
            return ExecuteQuery(queryable => queryable.Where(queryObject.SearchExpression));
        }

        /// <summary>
        /// Searches all roots that satisfy a <see cref="IQuery{TRoot, TId}"/> and allows for further filtering.
        /// </summary>
        /// <param name="queryObject">An instance of a <see cref="IQuery{TRoot, TId}"/>.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> to define an include statement.</param>
        /// <returns>A <see cref="IQueryable{T}"/>.</returns>
        public virtual IQueryable<TRoot> SearchEntitiesLazy(IQuery<TRoot, TId> queryObject, Func<IQueryable<TRoot>, IQueryable<TRoot>> includeFunc)
        {
            return ExecuteQuery(queryable => queryable.Where(queryObject.SearchExpression), includeFunc);
        }

        /// <inheritdoc/>
        public virtual RapidLaunchStatus UpdateRoots(IEnumerable<TRoot> roots)
        {
            return ExecuteCommand(() =>
            {
                var aggregateRoots = roots.ToList();

                Context.Set<TRoot>().UpdateRange(aggregateRoots);

                var rowCount = Context.SaveChanges();

                return (rowCount, aggregateRoots);
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> UpdateRootsAsync(IEnumerable<TRoot> roots, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
            {
                var aggregateRoots = roots.ToList();

                Context.Set<TRoot>().UpdateRange(aggregateRoots);

                var rowCount = await Context.SaveChangesAsync(cancellationToken);

                return (rowCount, aggregateRoots);
            },
                cancellationToken);
        }

        /// <inheritdoc/>
        public virtual RapidLaunchStatus UpdateRoot(TRoot root)
        {
            return ExecuteCommand(() =>
            {
                Context.Set<TRoot>().Update(root);

                var rowCount = Context.SaveChanges();

                return (rowCount, new List<TRoot> { root });
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> UpdateRootAsync(TRoot root, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
                {
                    Context.Set<TRoot>().Update(root);

                    var rowCount = await Context.SaveChangesAsync(cancellationToken);

                    return (rowCount, new List<TRoot> { root });
                },
                cancellationToken);
        }

        /// <summary>
        /// Executes a command against the persistence.
        /// </summary>
        /// <param name="executionFunc">A <see cref="Func{TResult}"/> that contains an operation to execute.</param>
        /// <param name="postOperationFunc">A <see cref="Func{TResult}"/> to run post operation effects.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> indicating the status of the operation.</returns>
        protected virtual RapidLaunchStatus ExecuteCommand(Func<(int RowCount, IEnumerable<TRoot> Entities)> executionFunc, Action<int, IEnumerable<IAggregateRoot<TId>>>? postOperationFunc = null)
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
        protected virtual async Task<RapidLaunchStatus> ExecuteCommandAsync(Func<Task<(int RowCount, IEnumerable<TRoot> Entities)>> executionFunc, CancellationToken cancellationToken, Func<int, IEnumerable<IAggregateRoot<TId>>, Task>? postOperationFunc = null)
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
        protected virtual IQueryable<TRoot> ExecuteQuery(Func<IQueryable<TRoot>, IQueryable<TRoot>> query, Func<IQueryable<TRoot>, IQueryable<TRoot>>? overrideFunc = null)
        {
            var includeFunc = _includeFunc ?? overrideFunc;

            var queryable = Context.Set<TRoot>();

            var afterInclude = includeFunc?.Invoke(queryable);

            return afterInclude != null ? query.Invoke(afterInclude) : query.Invoke(queryable);
        }

        /// <summary>
        /// Executes a query against the persistence.
        /// </summary>
        /// <param name="query">A <see cref="Func{TResult}"/> that contains the query.</param>
        /// <param name="overrideFunc">A <see cref="Func{TResult}"/> that may override the default include statement.</param>
        /// <returns>A <see cref="Task"/> of <see cref="List{T}"/> from the query operation.</returns>
        protected virtual async Task<List<TRoot>> ExecuteQueryAsync(Func<IQueryable<TRoot>, Task<List<TRoot>>> query, Func<IQueryable<TRoot>, IQueryable<TRoot>>? overrideFunc = null)
        {
            var includeFunc = _includeFunc ?? overrideFunc;

            var queryable = Context.Set<TRoot>();

            var afterInclude = includeFunc?.Invoke(queryable);

            return afterInclude != null ? await query.Invoke(afterInclude) : await query.Invoke(queryable);
        }
    }
}
