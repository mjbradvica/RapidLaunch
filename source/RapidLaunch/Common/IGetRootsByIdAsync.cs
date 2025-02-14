// <copyright file="IGetRootsByIdAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that retrieves entities by an enumerable identifier list.
    /// </summary>
    /// <typeparam name="TRoot">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IGetRootsByIdAsync<TRoot, in TId>
        where TRoot : IAggregateRoot<TId>
    {
        /// <summary>
        /// Retrieves a list of entities that match a parameter of identifiers.
        /// </summary>
        /// <param name="identifiers">A <see cref="IEnumerable{T}"/> of identifiers.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="List{T}"/> representing the asynchronous operation.</returns>
        Task<List<TRoot>> GetRootsByIdAsync(IEnumerable<TId> identifiers, CancellationToken cancellationToken = default);
    }
}
