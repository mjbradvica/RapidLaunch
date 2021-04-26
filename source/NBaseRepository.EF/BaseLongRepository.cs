using System;

namespace NBaseRepository.EF
{
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseLongRepository<T> : BaseRepository<T, long>
        where T : class, ILongEntity
    {
        protected BaseLongRepository(DbContext context)
            : base(context)
        {
        }

        protected BaseLongRepository(DbContext context, Func<DbSet<T>, DbSet<T>> includeFunc)
            : base(context, includeFunc)
        {
        }
    }
}
