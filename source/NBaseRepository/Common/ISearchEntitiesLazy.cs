namespace NBaseRepository.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface ISearchEntitiesLazy<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        IEnumerable<TEntity> SearchEntitiesLazy(IQuery<TEntity, TId> queryObject);

        IEnumerable<TEntity> SearchEntitiesLazy(IQuery<TEntity, TId> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}
