namespace NBaseRepository.EF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// A base repository of type <see cref="TEntity"/> with an Id of type <see cref="TId"/> that represents all possible operations.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public abstract class BaseRepository<TEntity, TId> :
        IAddEntityAsync<TEntity, TId>,
        IAddEntitiesAsync<TEntity, TId>,
        IGetByIdAsync<TEntity, TId>,
        IGetAllEntitiesAsync<TEntity, TId>,
        IGetAllEntitiesLazy<TEntity, TId>,
        IUpdateEntityAsync<TEntity, TId>,
        IUpdateEntitiesAsync<TEntity, TId>,
        IDeleteByIdAsync<TId>,
        IDeleteEntityAsync<TEntity, TId>,
        IDeleteEntitiesAsync<TEntity, TId>,
        ISearchEntitiesAsync<TEntity, TId>,
        ISearchEntitiesLazy<TEntity, TId>
        where TEntity : class, IEntity<TId>
    {
        private readonly Func<IQueryable<TEntity>, IQueryable<TEntity>> _includeFunc;

        protected BaseRepository(DbContext context)
        {
            Context = context;
        }

        protected BaseRepository(DbContext context, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            Context = context;
            _includeFunc = includeFunc;
        }

        protected DbContext Context { get; }

        /// <summary>
        /// Adds a single <see cref="TEntity"/> to the database.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be added to the database.</param>
        /// <param name="cancellationToken">A <see cref="Task"/> that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous save operation. The task result contains the a state entry written to the database.</returns>
        public virtual async Task<int> AddEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Context.Set<TEntity>().AddAsync(entity, cancellationToken);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Adds multiple <see cref="TEntity"/>s to the database.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to add to the database.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        public virtual async Task<int> AddEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves an <see cref="TEntity"/> from the database by Id.
        /// </summary>
        /// <param name="id">An Id of type <see cref="TId"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous get operation. The task results contains the <see cref="TEntity"/>.</returns>
        public virtual async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return await EntityContext().FirstAsync(entity => entity.Id.Equals(id), cancellationToken);
        }

        /// <summary>
        /// Retrieves an entity from the database by <see cref="TId"/> that accepts a custom include func for eager loading.
        /// </summary>
        /// <param name="id">An Id of type <see cref="TId"/>.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous get operation. The task results contains the <see cref="TEntity"/>.</returns>
        public virtual async Task<TEntity> GetByIdAsync(TId id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await includeFunc.Invoke(Context.Set<TEntity>()).FirstAsync(entity => entity.Id.Equals(id), cancellationToken);
        }

        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from the database.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous get all operations. The task results contains an <see cref="IReadOnlyList{TEntity}"/>.</returns>
        public virtual async Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await EntityContext().ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from the database that accepts a custom include func for eager loading.
        /// </summary>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous get all operations. The task results contains an <see cref="IReadOnlyList{TEntity}"/>.</returns>
        public virtual async Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await includeFunc.Invoke(Context.Set<TEntity>()).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from the database that may still be queried against.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{TEntity}"/>.</returns>
        public virtual IEnumerable<TEntity> GetAllEntitiesLazy()
        {
            return EntityContext();
        }

        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from the database that accepts a custom include func for eager loading that may still be queried against.
        /// </summary>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <returns>An <see cref="IEnumerable{TEntity}"/>.</returns>
        public virtual IEnumerable<TEntity> GetAllEntitiesLazy(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            return includeFunc.Invoke(Context.Set<TEntity>());
        }

        /// <summary>
        /// Updates an <see cref="TEntity"/> in the database.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be updated.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous update operation. The task result contains the state entry updated in the database.</returns>
        public virtual async Task<int> UpdateEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Context.Update(entity);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Updates a range <see cref="TEntity"/> in the database..
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to be updated.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous update operation. The task result contains the number of state entries updated in the database.</returns>
        public virtual async Task<int> UpdateEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().UpdateRange(entities);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Removes an entity from the database by <see cref="TId"/>.
        /// </summary>
        /// <param name="id">The <see cref="TId"/> used to delete the entity.</param>
        /// <param name="cancellationToken">A <see cref="Task"/> that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation. The task result contains the state entry deleted from the database.</returns>
        public virtual async Task<int> DeleteByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);

            return await DeleteEntityAsync(entity, cancellationToken);
        }

        /// <summary>
        /// Removes an <see cref="TEntity"/> from the database.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="Task"/> that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation. The task result contains the number of state entries deleted from the database.</returns>
        public virtual async Task<int> DeleteEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().Remove(entity);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Removes multiple <see cref="TEntity"/> from the database.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation. The task result contains the number of state entries deleted from the database.</returns>
        public virtual async Task<int> DeleteEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().RemoveRange(entities);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Performs a series of filters and/or joins on a <see cref="TEntity"/> against the database.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity,TId}"/> that contains a query expression.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous get all operations. The task results contains an <see cref="IReadOnlyList{TEntity}"/>.</returns>
        public virtual async Task<IReadOnlyList<TEntity>> SearchEntitiesAsync(IQuery<TEntity, TId> queryObject, CancellationToken cancellationToken = default)
        {
            return await EntityContext().Where(queryObject.SearchExpression).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Performs a series of filters and/or joins on a <see cref="TEntity"/> that accepts a customer include func for eager loading against the database.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity,TId}"/> that contains a query expression.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous get all operations. The task results contains an <see cref="IReadOnlyList{TEntity}"/>.</returns>
        public virtual async Task<IReadOnlyList<TEntity>> SearchEntitiesAsync(IQuery<TEntity, TId> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await includeFunc.Invoke(Context.Set<TEntity>()).Where(queryObject.SearchExpression).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Performs a series of filters and/or joins on a <see cref="TEntity"/> against the database that has not been executed.
        /// </summary>
        /// <param name="queryObject">A query object that contains a query expression.</param>
        /// <returns>An <see cref="IEnumerable{TEntity}"/> that may be queried against.</returns>
        public virtual IEnumerable<TEntity> SearchEntitiesLazy(IQuery<TEntity, TId> queryObject)
        {
            return EntityContext().Where(queryObject.SearchExpression);
        }

        /// <summary>
        /// Performs a series of filters and/or joins on a <see cref="TEntity"/> against the database that accepts a customer include func that has not been executed.
        /// </summary>
        /// <param name="queryObject">A query object of type <see cref="IQuery{TEntity,TId}"/> that contains a query expression.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <returns>An <see cref="IEnumerable{TEntity}"/> that may be queried against.</returns>
        public virtual IEnumerable<TEntity> SearchEntitiesLazy(IQuery<TEntity, TId> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            return includeFunc.Invoke(Context.Set<TEntity>()).Where(queryObject.SearchExpression);
        }

        private IQueryable<TEntity> EntityContext()
        {
            return _includeFunc != null ? _includeFunc.Invoke(Context.Set<TEntity>()) : Context.Set<TEntity>();
        }
    }
}
