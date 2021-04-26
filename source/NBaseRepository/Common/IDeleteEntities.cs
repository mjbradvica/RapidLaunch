namespace NBaseRepository.Common
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDeleteEntities<in TEntity, TId>
        where TEntity : IEntity<TId>
    {
        Task<int> DeleteEntities(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    }
}
