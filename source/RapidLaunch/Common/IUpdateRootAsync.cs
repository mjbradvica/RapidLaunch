﻿// <copyright file="IUpdateRootAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can update a root asynchronously.
    /// </summary>
    /// <typeparam name="TRoot">The type of the root.The type of the root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IUpdateRootAsync<in TRoot, TId>
        where TRoot : IAggregateRoot<TId>
    {
        /// <summary>
        /// Updates a root in a collection.
        /// </summary>
        /// <param name="root">An updated version of the root.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="RapidLaunchStatus"/> that represents the asynchronous save operation.</returns>
        Task<RapidLaunchStatus> UpdateRootAsync(TRoot root, CancellationToken cancellationToken = default);
    }
}
