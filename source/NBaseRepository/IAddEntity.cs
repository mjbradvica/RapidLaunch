﻿namespace NBaseRepository
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An interface that allows a class to add a single entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IAddEntity<in TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Adds a single entity to a collection.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A Task object.</returns>
        Task<int> AddEntity(TEntity entity, CancellationToken cancellationToken);
    }
}