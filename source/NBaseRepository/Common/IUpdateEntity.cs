namespace NBaseRepository.Common
{
    /// <summary>
    /// An interface used to describe a class that can update an entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.The type of the Id.</typeparam>
    public interface IUpdateEntity<in TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Updates an <see cref="TEntity"/> in a collection.
        /// </summary>
        /// <param name="entity">A new version of the <see cref="TEntity"/>.</param>
        /// <returns>A <see cref="int"/> that contains the number of state entries updated in the database.</returns>
        int UpdateEntity(TEntity entity);
    }
}