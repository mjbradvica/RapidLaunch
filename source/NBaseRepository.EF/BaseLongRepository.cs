namespace NBaseRepository.EF
{
    using System;
    using System.Linq;
    using LongPrimary;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class BaseLongRepository<TEntity> : BaseRepository<TEntity, long>
        where TEntity : class, ILongEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected BaseLongRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="includeFunc"></param>
        protected BaseLongRepository(DbContext context, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
            : base(context, includeFunc)
        {
        }
    }
}
