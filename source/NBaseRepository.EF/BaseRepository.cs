namespace NBaseRepository.EF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseRepository<TEntity, TId> :
        IAddEntity<TEntity, TId>,
        IAddEntities<TEntity, TId>,
        IGetById<TEntity, TId>,
        IGetAllEntities<TEntity, TId>,
        IUpdateEntity<TEntity, TId>,
        IUpdateEntities<TEntity, TId>,
        IDeleteEntityById<TId>,
        IDeleteEntity<TEntity, TId>,
        IDeleteEntities<TEntity, TId>,
        ISearchEntities<TEntity, TId>
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

        public virtual async Task<int> AddEntity(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Context.Set<TEntity>().AddAsync(entity, cancellationToken);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<int> AddEntities(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetById(TId id, CancellationToken cancellationToken = default)
        {
            return await EntityContext().FirstAsync(entity => entity.Id.Equals(id), cancellationToken);
        }

        public virtual async Task<TEntity> GetById(TId id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await includeFunc.Invoke(Context.Set<TEntity>()).FirstAsync(entity => entity.Id.Equals(id), cancellationToken);
        }

        public virtual async Task<IReadOnlyList<TEntity>> GetAllEntities(CancellationToken cancellationToken = default)
        {
            return await EntityContext().ToListAsync(cancellationToken);
        }

        public virtual async Task<IReadOnlyList<TEntity>> GetAllEntities(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await includeFunc.Invoke(Context.Set<TEntity>()).ToListAsync(cancellationToken);
        }

        public virtual async Task<int> UpdateEntity(TEntity entity, CancellationToken cancellationToken = default)
        {
            Context.Update(entity);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<int> UpdateEntities(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().UpdateRange(entities);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<int> DeleteEntityById(TId id, CancellationToken cancellationToken = default)
        {
            var entity = await GetById(id, cancellationToken);

            return await DeleteEntity(entity, cancellationToken);
        }

        public virtual async Task<int> DeleteEntity(TEntity entity, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().Remove(entity);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<int> DeleteEntities(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().RemoveRange(entities);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<IReadOnlyList<TEntity>> SearchEntities(IQuery<TEntity, TId> queryObject, CancellationToken cancellationToken = default)
        {
            return await Context.Set<TEntity>().Where(queryObject.SearchExpression).ToListAsync(cancellationToken);
        }

        private IQueryable<TEntity> EntityContext()
        {
            return _includeFunc != null ? _includeFunc.Invoke(Context.Set<TEntity>()) : Context.Set<TEntity>();
        }
    }
}
