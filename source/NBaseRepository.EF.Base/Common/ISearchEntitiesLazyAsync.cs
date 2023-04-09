namespace NBaseRepository.EF.Base.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NBaseRepository.Common;

    public interface ISearchEntitiesLazyAsync<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        Task<IEnumerable<TEntity>> SearchEntitiesLazyAsync(IQuery<TEntity> queryObject);

        Task<IEnumerable<TEntity>> SearchEntitiesLazyAsync(IQuery<TEntity> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}
