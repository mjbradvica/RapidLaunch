// <copyright file="ISearchEntitiesLazyAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that search for entities both lazily and asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface ISearchEntitiesLazyAsync<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Searches through an entity list using a query object both lazily and asynchronously.
        /// </summary>
        /// <param name="queryObject">A query object used for the search.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<TEntity>> SearchEntitiesLazyAsync(IQuery<TEntity> queryObject);

        /// <summary>
        /// Searches through an entity list using a query object both lazily and asynchronously using a custom conversion function.
        /// </summary>
        /// <param name="queryObject">A query object used for the search.</param>
        /// <param name="includeFunc">A customer conversion function for including related entities.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<TEntity>> SearchEntitiesLazyAsync(IQuery<TEntity> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}
