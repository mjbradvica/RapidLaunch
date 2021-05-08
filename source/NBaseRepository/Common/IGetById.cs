namespace NBaseRepository.Common
{
    using System;
    using System.Linq;

    /// <summary>
    /// An interface used to describe a class that can retrieve a single entity of type <see cref="TEntity"/> by an Id of type <see cref="TId"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IGetById<TEntity, in TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Retrieves an <see cref="TEntity"/> from a collection by Id.
        /// </summary>
        /// <param name="id">The Id of type <see cref="TId"/>.</param>
        /// <returns>An object of type <see cref="TEntity"/>.</returns>
        TEntity GetById(TId id);

        /// <summary>
        /// Retrieves an entity from a collection by Id that accepts a custom include func for eager loading.
        /// </summary>
        /// <param name="id">The Id of type <see cref="TId"/>.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <returns>An object of type <see cref="TEntity"/>.</returns>
        TEntity GetById(TId id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}