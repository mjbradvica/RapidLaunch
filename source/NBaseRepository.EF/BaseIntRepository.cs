namespace NBaseRepository.EF
{
    using System;
    using System.Linq;
    using IntPrimary;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
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
        /// <param name="includeFunc"></param>
        protected BaseIntRepository(DbContext context, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
            : base(context, includeFunc)
        {
        }
    }
}
