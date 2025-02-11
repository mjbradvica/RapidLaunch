// <copyright file="IDeleteEntity.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can delete an entity.
    /// </summary>
    /// <typeparam name="TRoot">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IDeleteEntity<in TRoot, TId>
        where TRoot : IAggregateRoot<TId>
    {
        /// <summary>
        /// Removes an root from a collection.
        /// </summary>
        /// <param name="root">The root to be deleted.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> that indicates the status of the operation.</returns>
        RapidLaunchStatus DeleteEntity(TRoot root);
    }
}