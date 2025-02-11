// <copyright file="IUpdateEntitiesAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
	/// <summary>
	/// An interface used to describe a class that can update a range of entities asynchronously.
	/// </summary>
	/// <typeparam name="TRoot">The type of the entity.</typeparam>
	/// <typeparam name="TId">The type of the identifier.</typeparam>
	public interface IUpdateEntitiesAsync<in TRoot, TId>
        where TRoot : IAggregateRoot<TId>
    {
        /// <summary>
        /// Updates a range of roots in a collection.
        /// </summary>
        /// <param name="roots">An <see cref="IEnumerable{TEntity}"/> to be updated.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="RapidLaunchStatus"/> that represents the asynchronous operation.</returns>
        Task<RapidLaunchStatus> UpdateEntitiesAsync(IEnumerable<TRoot> roots, CancellationToken cancellationToken = default);
    }
}
