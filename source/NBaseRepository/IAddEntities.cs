namespace NBaseRepository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// An interface used to describe a class that can add multiple entities at one time.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entities.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IAddEntities<in TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Adds multiples entities to a collection.
        /// </summary>
        /// <param name="entities">An IEnumerable of the entities to be added.</param>
        /// <returns>A Task object.</returns>
        Task AddEntities(IEnumerable<TEntity> entities);
    }
}
