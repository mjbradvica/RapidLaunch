namespace NBaseRepository
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ISearchEntities<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        Task<IReadOnlyList<TEntity>> SearchEntities(IQuery<TEntity, TId> queryObject, CancellationToken cancellationToken);
    }
}
