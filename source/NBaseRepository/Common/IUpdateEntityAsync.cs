namespace NBaseRepository.Common
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An interface used to describe a class that can update an entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.The type of the Id.</typeparam>
    public interface IUpdateEntityAsync<in TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Updates an <see cref="TEntity"/> in a collection.
        /// </summary>
        /// <param name="entity">A new version of the <see cref="TEntity"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> UpdateEntityAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
