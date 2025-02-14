// <copyright file="IDeleteRoots.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can delete multiple entities.
    /// </summary>
    /// <typeparam name="TRoot">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IDeleteRoots<in TRoot, TId>
        where TRoot : IAggregateRoot<TId>
    {
        /// <summary>
        /// Removes multiple roots from a collection.
        /// </summary>
        /// <param name="roots">An <see cref="IEnumerable{TEntity}"/> to be deleted.</param>
        /// <returns>An <see cref="RapidLaunchStatus"/> indicating the status of the operation.</returns>
        RapidLaunchStatus DeleteRoots(IEnumerable<TRoot> roots);
    }
}