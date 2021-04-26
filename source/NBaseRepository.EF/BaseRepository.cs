namespace NBaseRepository.EF
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseRepository<TEntity, TId> :
        IAddEntities<TEntity, TId>,
        IGetById<TEntity, TId>,
        IGetAllEntities<TEntity, TId>
        where TEntity : class, IEntity<TId>
    {
        private readonly Func<DbSet<TEntity>, DbSet<TEntity>> _includeFunc;

        protected BaseRepository(DbContext context)
        {
            Context = context;
        }

        protected BaseRepository(DbContext context, Func<DbSet<TEntity>, DbSet<TEntity>> includeFunc)
        {
            Context = context;
            _includeFunc = includeFunc;
        }

        protected DbContext Context { get; }

        public virtual async Task AddEntities(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);

            await Context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetById(TId id)
        {
            return await EntityContext().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<TEntity>> GetAllEntities()
        {
            return await EntityContext().ToListAsync();
        }

        private DbSet<TEntity> EntityContext()
        {
            return _includeFunc != null ? _includeFunc.Invoke(Context.Set<TEntity>()) : Context.Set<TEntity>();
        }
    }
}
