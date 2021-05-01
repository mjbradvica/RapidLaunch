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
    public interface IGetAllEntitiesLazy<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAllEntitiesLazy();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeFunc"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAllEntitiesLazy(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}
