namespace NBaseRepository.EF
{
    using System;
    using System.Linq;
    using GuidPrimary;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class BaseGuidRepository<TEntity> : BaseRepository<TEntity, Guid>
        where TEntity : class, IGuidEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected BaseGuidRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        protected BaseGuidRepository(DbContext context, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
            : base(context, includeFunc)
        {
        }
    }
}
