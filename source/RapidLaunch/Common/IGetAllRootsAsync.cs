// <copyright file="IGetAllRootsAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all roots asynchronously.
    /// </summary>
    /// <typeparam name="TRoot">The type of the root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    public interface IGetAllRootsAsync<TRoot, in TId, out TEvent>
        where TRoot : IAggregateRoot<TId, TEvent>
        where TEvent : class
    {
        /// <summary>
        /// Retrieves all roots from a collection.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="List{TRoot}"/>.</returns>
        Task<List<TRoot>> GetAllRootsAsync(CancellationToken cancellationToken = default);
    }
}
