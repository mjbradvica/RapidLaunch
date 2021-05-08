namespace NBaseRepository.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// An interface used to describe a class that can delete multiple entities of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IDeleteEntities<in TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Removes multiple <see cref="TEntity"/> from a collection.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to be deleted.</param>
        /// <returns>An <see cref="int"/> that contains the number of state entries deleted from the database.</returns>
        int DeleteEntities(IEnumerable<TEntity> entities);
    }
}