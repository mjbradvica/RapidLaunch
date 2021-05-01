namespace NBaseRepository.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
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
        /// <param name="includeFunc"></param>
        /// <returns></returns>
        IEnumerable<TEntity> SearchEntitiesLazy(IQuery<TEntity, TId> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}
