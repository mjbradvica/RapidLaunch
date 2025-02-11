// <copyright file="ISearchEntitiesAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
	/// <summary>
	/// An interface used to describe a class that can perform basic filters and/or joins.
	/// </summary>
	/// <typeparam name="TRoot">The type of the aggregate root.</typeparam>
	/// <typeparam name="TId">The type of the identifier.</typeparam>
	public interface ISearchEntitiesAsync<TRoot, TId>
        where TRoot : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Performs a series of filters and/or joins on a root against a collection.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity}"/> that contains a query expression.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="List{T}"/>.</returns>
        Task<List<TRoot>> SearchEntitiesAsync(IQuery<TRoot> queryObject, CancellationToken cancellationToken = default);
    }
}
