﻿// <copyright file="IGetByIdAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can retrieve a single entity by an identifier.
    /// </summary>
    /// <typeparam name="TRoot">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IGetByIdAsync<TRoot, in TId>
        where TRoot : IAggregateRoot<TId>
    {
        /// <summary>
        /// Retrieves an entity from a collection by an identifier.
        /// </summary>
        /// <param name="id">The identifier for the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>The desired entity.</returns>
        Task<TRoot?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    }
}
