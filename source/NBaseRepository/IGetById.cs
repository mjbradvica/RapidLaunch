namespace NBaseRepository
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// An interface used to describe a class that can retrieve a single entity by GUID.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IGetById<TEntity, in TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Retrieves an entity from a collection by its' GUID.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        /// <returns>An object of type TEntity.</returns>
        Task<TEntity> GetById(TId id);
    }
}
