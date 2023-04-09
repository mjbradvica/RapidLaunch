namespace NBaseRepository.EF.Base.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NBaseRepository.Common;

    public interface IGetAllEntitiesLazyAsync<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        Task<IEnumerable<TEntity>> GetAllEntitiesLazyAsync();

        Task<IEnumerable<TEntity>> GetAllEntitiesLazyAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}
