namespace NBaseRepository.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public interface ISearchEntities<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryObject"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IReadOnlyList<TEntity>> SearchEntities(IQuery<TEntity, TId> queryObject, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryObject"></param>
        /// <param name="includeFunc"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IReadOnlyList<TEntity>> SearchEntities(IQuery<TEntity, TId> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken);
    }
}
