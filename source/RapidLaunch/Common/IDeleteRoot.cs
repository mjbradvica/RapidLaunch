// <copyright file="IDeleteRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can delete a root.
    /// </summary>
    /// <typeparam name="TRoot">The type of the root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    public interface IDeleteRoot<in TRoot, in TId, out TEvent>
        where TRoot : IAggregateRoot<TId, TEvent>
        where TEvent : class
    {
        /// <summary>
        /// Removes a root from a collection.
        /// </summary>
        /// <param name="root">The root to be deleted.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> that indicates the status of the operation.</returns>
        RapidLaunchStatus DeleteRoot(TRoot root);
    }
}