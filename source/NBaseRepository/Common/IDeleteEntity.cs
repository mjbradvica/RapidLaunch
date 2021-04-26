namespace NBaseRepository.Common
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDeleteEntity<in TEntity, TId>
        where TEntity : IEntity<TId>
    {
        Task<int> DeleteEntity(TEntity entity, CancellationToken cancellationToken);
    }
}
