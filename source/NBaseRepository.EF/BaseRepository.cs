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
        IUpdateEntity<TEntity, TId>
        where TEntity : class, IEntity<TId>
        where TId : struct
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

        public virtual async Task AddEntities(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);

            await Context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetById(TId id)
        {
            return await EntityContext().FirstAsync(entity => entity.Id.Equals(id));
        }

        public virtual async Task<IReadOnlyList<TEntity>> GetAllEntities()
        {
            return await EntityContext().ToListAsync();
        }

        public virtual async Task<int> UpdateEntity(TEntity entity, CancellationToken cancellationToken = default)
        {
            Context.Update(entity);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        private IQueryable<TEntity> EntityContext()
        {
            return _includeFunc != null ? _includeFunc.Invoke(Context.Set<TEntity>()) : Context.Set<TEntity>();
        }
    }
}
