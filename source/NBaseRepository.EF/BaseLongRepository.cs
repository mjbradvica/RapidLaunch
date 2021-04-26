namespace NBaseRepository.EF
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseLongRepository<T> : BaseRepository<T, long>
        where T : class, ILongEntity
    {
        protected BaseLongRepository(DbContext context)
            : base(context)
        {
        }

        protected BaseLongRepository(DbContext context, Func<IQueryable<T>, IQueryable<T>> includeFunc)
            : base(context, includeFunc)
        {
        }
    }
}
