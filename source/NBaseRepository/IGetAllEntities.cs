namespace NBaseRepository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// An interface used to describe a class that can retrieve all entities of a certain type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IGetAllEntities<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Retrieves all entities of a type from a collection.
        /// </summary>
        /// <returns>A Task of List of TEntities.</returns>
        Task<IReadOnlyList<TEntity>> GetAllEntities();
    }
}
