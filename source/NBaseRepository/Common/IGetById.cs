﻿namespace NBaseRepository.Common
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An interface used to describe a class that can retrieve a single entity of type <see cref="TEntity"/> by Id of type <see cref="TId"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IGetById<TEntity, in TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Retrieves an entity from a collection by its' Id.
        /// </summary>
        /// <param name="id">The Id of the entity.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>An object of type <see cref="TEntity"/>.</returns>
        Task<TEntity> GetById(TId id, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves an entity from a collection by its' Id that accepts a custom include func for eager loading.
        /// </summary>
        /// <param name="id">The Id of the entity.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>An object of type <see cref="TEntity"/>.</returns>
        Task<TEntity> GetById(TId id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken);
    }
}
