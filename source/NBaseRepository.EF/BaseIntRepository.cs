namespace NBaseRepository.EF
{
    using System;
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseIntRepository<T> : BaseRepository<T, int>
        where T : class, IIntEntity
    {
        protected BaseIntRepository(DbContext context)
            : base(context)
        {
        }

        protected BaseIntRepository(DbContext context, Func<DbSet<T>, DbSet<T>> includeFunc)
            : base(context, includeFunc)
        {
        }
    }
}
