namespace NBaseRepository.EF
{
    using System;
    using System.Linq;
    using GuidPrimary;
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseGuidRepository<TEntity> : BaseRepository<TEntity, Guid>
        where TEntity : class, IGuidEntity
    {
        protected BaseGuidRepository(DbContext context)
            : base(context)
        {
        }

        protected BaseGuidRepository(DbContext context, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
            : base(context, includeFunc)
        {
        }
    }
}
