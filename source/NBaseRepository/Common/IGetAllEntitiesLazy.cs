namespace NBaseRepository.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// An interface used to describe a class that can retrieve all entity of type <see cref="TEntity"/> lazily.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IGetAllEntitiesLazy<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from a collection that may still be queried against.
        /// </summary>
        /// <returns>An IEnumerable of type <see cref="TEntity"/>.</returns>
        IEnumerable<TEntity> GetAllEntitiesLazy();

        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from a collection that accepts a custom include func for eager loading that may still be queried against.
        /// </summary>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <returns>An IEnumerable of type <see cref="TEntity"/>.</returns>
        IEnumerable<TEntity> GetAllEntitiesLazy(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}
