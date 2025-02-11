// <copyright file="IUpdateEntityAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can update an entity asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IUpdateEntityAsync<in TEntity, TId>
        where TEntity : IAggregateRoot<TId>
    {
        /// <summary>
        /// Updates an entity in a collection.
        /// </summary>
        /// <param name="entity">An updated version of the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="RapidLaunchStatus"/> that represents the asynchronous save operation.</returns>
        Task<RapidLaunchStatus> UpdateEntityAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
