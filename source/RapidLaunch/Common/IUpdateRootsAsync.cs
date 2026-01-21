// <copyright file="IUpdateRootsAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can update a range of roots asynchronously.
    /// </summary>
    /// <typeparam name="TRoot">The type of the root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    public interface IUpdateRootsAsync<in TRoot, in TId, out TEvent>
        where TRoot : IAggregateRoot<TId, TEvent>
        where TEvent : class
    {
        /// <summary>
        /// Updates a range of roots in a collection.
        /// </summary>
        /// <param name="roots">An <see cref="IEnumerable{TRoot}"/> to be updated.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="RapidLaunchStatus"/> that represents the asynchronous operation.</returns>
        Task<RapidLaunchStatus> UpdateRootsAsync(IEnumerable<TRoot> roots, CancellationToken cancellationToken = default);
    }
}
