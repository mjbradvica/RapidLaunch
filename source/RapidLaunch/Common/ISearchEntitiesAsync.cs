// <copyright file="ISearchEntitiesAsync.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface ISearchEntitiesAsync<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Performs a series of filters and/or joins on an entity against a collection.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity}"/> that contains a query expression.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="List{T}"/>.</returns>
        Task<List<TEntity>> SearchEntitiesAsync(IQuery<TEntity> queryObject, CancellationToken cancellationToken);
    }
}
