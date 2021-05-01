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
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public abstract class BaseRepository<TEntity, TId> :
        IAddEntity<TEntity, TId>,
        IAddEntities<TEntity, TId>,
        IGetById<TEntity, TId>,
        IGetAllEntities<TEntity, TId>,
        IGetAllEntitiesLazy<TEntity, TId>,
        IUpdateEntity<TEntity, TId>,
        IUpdateEntities<TEntity, TId>,
        IDeleteById<TId>,
        IDeleteEntity<TEntity, TId>,
        IDeleteEntities<TEntity, TId>,
        ISearchEntities<TEntity, TId>,
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
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken">A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</param>
        /// <returns></returns>
        public virtual async Task<int> AddEntity(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Context.Set<TEntity>().AddAsync(entity, cancellationToken);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken">A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</param>
        /// <returns></returns>
        public virtual async Task<int> AddEntities(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</param>
        /// <returns></returns>
        public virtual async Task<TEntity> GetById(TId id, CancellationToken cancellationToken = default)
        {
            return await EntityContext().FirstAsync(entity => entity.Id.Equals(id), cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeFunc"></param>
        /// <param name="cancellationToken">A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</param>
        /// <returns></returns>
        public virtual async Task<TEntity> GetById(TId id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await includeFunc.Invoke(Context.Set<TEntity>()).FirstAsync(entity => entity.Id.Equals(id), cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken">A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</param>
        /// <returns></returns>
        public virtual async Task<IReadOnlyList<TEntity>> GetAllEntities(CancellationToken cancellationToken = default)
        {
            return await EntityContext().ToListAsync(cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeFunc"></param>
        /// <param name="cancellationToken">A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</param>
        /// <returns></returns>
        public virtual async Task<IReadOnlyList<TEntity>> GetAllEntities(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await includeFunc.Invoke(Context.Set<TEntity>()).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAllEntitiesLazy()
        {
            return EntityContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeFunc"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAllEntitiesLazy(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            return includeFunc.Invoke(Context.Set<TEntity>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken">A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</param>
        /// <returns></returns>
        public virtual async Task<int> UpdateEntity(TEntity entity, CancellationToken cancellationToken = default)
        {
            Context.Update(entity);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken">A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</param>
        /// <returns></returns>
        public virtual async Task<int> UpdateEntities(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().UpdateRange(entities);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</param>
        /// <returns></returns>
        public virtual async Task<int> DeleteById(TId id, CancellationToken cancellationToken = default)
        {
            var entity = await GetById(id, cancellationToken);

            return await DeleteEntity(entity, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken">A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</param>
        /// <returns></returns>
        public virtual async Task<int> DeleteEntity(TEntity entity, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().Remove(entity);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken">A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</param>
        /// <returns></returns>
        public virtual async Task<int> DeleteEntities(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().RemoveRange(entities);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryObject"></param>
        /// <param name="cancellationToken">A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</param>
        /// <returns></returns>
        public virtual async Task<IReadOnlyList<TEntity>> SearchEntities(IQuery<TEntity, TId> queryObject, CancellationToken cancellationToken = default)
        {
            return await EntityContext().Where(queryObject.SearchExpression).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryObject"></param>
        /// <param name="includeFunc"></param>
        /// <param name="cancellationToken">A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</param>
        /// <returns></returns>
        public virtual async Task<IReadOnlyList<TEntity>> SearchEntities(IQuery<TEntity, TId> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await includeFunc.Invoke(Context.Set<TEntity>()).Where(queryObject.SearchExpression).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryObject"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> SearchEntitiesLazy(IQuery<TEntity, TId> queryObject)
        {
            return EntityContext().Where(queryObject.SearchExpression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryObject"></param>
        /// <param name="includeFunc"></param>
        /// <returns></returns>
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
