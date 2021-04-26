namespace NBaseRepository.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IGetAllEntitiesLazy<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        IEnumerable<TEntity> GetAllEntitiesLazy();

        IEnumerable<TEntity> GetAllEntitiesLazy(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}
