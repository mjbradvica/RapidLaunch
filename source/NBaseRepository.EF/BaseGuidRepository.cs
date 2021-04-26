namespace NBaseRepository.EF
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseGuidRepository<T> : BaseRepository<T, Guid>
        where T : class, IGuidEntity
    {
        protected BaseGuidRepository(DbContext context)
            : base(context)
        {
        }

        protected BaseGuidRepository(DbContext context, Func<IQueryable<T>, IQueryable<T>> includeFunc)
            : base(context, includeFunc)
        {
        }
    }
}
