namespace NBaseRepository.Common
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An interface that allows a class to add a single entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IAddEntityAsync<in TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Adds a single <see cref="TEntity"/> to a collection.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be added.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> AddEntityAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
