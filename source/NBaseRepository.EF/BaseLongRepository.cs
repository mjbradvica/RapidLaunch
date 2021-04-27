namespace NBaseRepository.EF
{
    using System;
    using System.Linq;
    using LongPrimary;
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseLongRepository<TEntity> : BaseRepository<TEntity, long>
        where TEntity : class, ILongEntity
    {
        protected BaseLongRepository(DbContext context)
            : base(context)
        {
        }

        protected BaseLongRepository(DbContext context, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
            : base(context, includeFunc)
        {
        }
    }
}
