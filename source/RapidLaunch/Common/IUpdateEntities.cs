// <copyright file="IUpdateEntities.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can update a range of entities.
    /// </summary>
    /// <typeparam name="TRoot">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IUpdateEntities<in TRoot, TId>
        where TRoot : IAggregateRoot<TId>
    {
        /// <summary>
        /// Updates a range of roots in a collection.
        /// </summary>
        /// <param name="roots">An <see cref="IEnumerable{TEntity}"/> to be updated.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> that contains the status of the operation.</returns>
        RapidLaunchStatus UpdateEntities(IEnumerable<TRoot> roots);
    }
}