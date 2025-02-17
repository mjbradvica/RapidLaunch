// <copyright file="IUpdateRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can update a root.
    /// </summary>
    /// <typeparam name="TRoot">The type of the root.The type of the root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IUpdateRoot<in TRoot, TId>
        where TRoot : IAggregateRoot<TId>
    {
        /// <summary>
        /// Updates a root in a collection.
        /// </summary>
        /// <param name="root">An updated version of the root.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> indicating the status of the operation.</returns>
        RapidLaunchStatus UpdateRoot(TRoot root);
    }
}