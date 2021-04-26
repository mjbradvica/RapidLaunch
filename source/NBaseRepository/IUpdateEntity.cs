namespace NBaseRepository
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An interface used to describe a class that can update an entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IUpdateEntity<in TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Updates an entity in a collection.
        /// </summary>
        /// <param name="entity">A new version of the entity.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A Task object.</returns>
        Task<int> UpdateEntity(TEntity entity, CancellationToken cancellationToken);
    }
}
