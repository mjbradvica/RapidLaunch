namespace NBaseRepository.EF
{
    using System;
    using System.Linq;
    using IntPrimary;
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseIntRepository<TEntity> : BaseRepository<TEntity, int>
        where TEntity : class, IIntEntity
    {
        protected BaseIntRepository(DbContext context)
            : base(context)
        {
        }

        protected BaseIntRepository(DbContext context, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
            : base(context, includeFunc)
        {
        }
    }
}
