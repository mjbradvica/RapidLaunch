// <copyright file="ISearchRootsLazy.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins for a root lazily.
    /// </summary>
    /// <typeparam name="TRoot">The type of the root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface ISearchRootsLazy<TRoot, TId>
        where TRoot : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Performs a series of filters and/or joins on a root against a collection that has not been executed.
        /// </summary>
        /// <param name="queryObject">A query object of type <see cref="IQuery{TEntity, TId}"/> that contains a query expression.</param>
        /// <returns>An <see cref="IQueryable{TEntity}"/>.</returns>
        IQueryable<TRoot> SearchRootsLazy(IQuery<TRoot, TId> queryObject);
    }
}
