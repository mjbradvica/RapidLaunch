// <copyright file="IGetAllRootsAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all entities asynchronously.
    /// </summary>
    /// <typeparam name="TRoot">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IGetAllRootsAsync<TRoot, TId>
        where TRoot : IAggregateRoot<TId>
    {
        /// <summary>
        /// Retrieves all entities from a collection.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="List{TEntity}"/>.</returns>
        Task<List<TRoot>> GetAllRootsAsync(CancellationToken cancellationToken = default);
    }
}
