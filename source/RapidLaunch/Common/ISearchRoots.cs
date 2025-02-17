// <copyright file="ISearchRoots.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins.
    /// </summary>
    /// <typeparam name="TRoot">The type of the root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface ISearchRoots<TRoot, TId>
        where TRoot : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Performs a series of filters and/or joins on a root against a collection.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity, TId}"/> that contains a query expression.</param>
        /// <returns>A <see cref="List{T}"/>.</returns>
        List<TRoot> SearchRoots(IQuery<TRoot, TId> queryObject);
    }
}