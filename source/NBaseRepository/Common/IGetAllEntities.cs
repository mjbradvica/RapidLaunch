namespace NBaseRepository.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// An interface used to describe a class that can retrieve all entities of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IGetAllEntities<out TEntity, TId, TIn, TOut>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from a collection.
        /// </summary>
        /// <returns>A of <see cref="IReadOnlyList{TEntity}"/>.</returns>
        IReadOnlyList<TEntity> GetAllEntities();

        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from a collection that accepts a custom include func for eager loading.
        /// </summary>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <returns>A of <see cref="IReadOnlyList{TEntity}"/>.</returns>
        IReadOnlyList<TEntity> GetAllEntities(Func<TIn, TOut> includeFunc);
    }
}