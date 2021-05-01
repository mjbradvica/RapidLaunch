namespace NBaseRepository.EF
{
    using System;
    using System.Linq;
    using IntPrimary;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class BaseIntRepository<TEntity> : BaseRepository<TEntity, int>
        where TEntity : class, IIntEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected BaseIntRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        protected BaseIntRepository(DbContext context, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
            : base(context, includeFunc)
        {
        }
    }
}
