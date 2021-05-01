namespace NBaseRepository.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface ISearchEntitiesLazy<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryObject"></param>
        /// <returns></returns>
        IEnumerable<TEntity> SearchEntitiesLazy(IQuery<TEntity, TId> queryObject);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryObject"></param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <returns></returns>
        IEnumerable<TEntity> SearchEntitiesLazy(IQuery<TEntity, TId> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}
