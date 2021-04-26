namespace NBaseRepository.EF
{
    using System;
    using System.Linq;
    using IntPrimary;
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseIntRepository<T> : BaseRepository<T, int>
        where T : class, IIntEntity
    {
        protected BaseIntRepository(DbContext context)
            : base(context)
        {
        }

        protected BaseIntRepository(DbContext context, Func<IQueryable<T>, IQueryable<T>> includeFunc)
            : base(context, includeFunc)
        {
        }
    }
}
