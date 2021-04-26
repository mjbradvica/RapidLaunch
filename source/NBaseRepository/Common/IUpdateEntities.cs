namespace NBaseRepository.Common
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IUpdateEntities<in TEntity, TId>
        where TEntity : IEntity<TId>
    {
        Task<int> UpdateEntities(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    }
}
