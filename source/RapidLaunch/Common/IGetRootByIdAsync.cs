// <copyright file="IGetRootByIdAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can retrieve a single root by an identifier.
    /// </summary>
    /// <typeparam name="TRoot">The type of the root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IGetRootByIdAsync<TRoot, in TId>
        where TRoot : IAggregateRoot<TId>
    {
        /// <summary>
        /// Retrieves a root from a collection by an identifier.
        /// </summary>
        /// <param name="id">The identifier for the root.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>The desired root.</returns>
        Task<TRoot?> GetRootByIdAsync(TId id, CancellationToken cancellationToken = default);
    }
}
