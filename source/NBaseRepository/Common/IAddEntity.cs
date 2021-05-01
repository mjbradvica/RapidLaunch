namespace NBaseRepository.Common
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An interface that allows a class to add a single entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IAddEntity<in TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Adds a single entity to a collection.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> AddEntity(TEntity entity, CancellationToken cancellationToken);
    }
}
