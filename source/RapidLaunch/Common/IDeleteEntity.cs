// <copyright file="IDeleteEntity.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can delete an entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IDeleteEntity<in TEntity, TId>
        where TEntity : IAggregateRoot<TId>
    {
        /// <summary>
        /// Removes an entity from a collection.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> that indicates the status of the operation.</returns>
        RapidLaunchStatus DeleteEntity(TEntity entity);
    }
}