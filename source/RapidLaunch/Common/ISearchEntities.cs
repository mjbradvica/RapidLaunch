// <copyright file="ISearchEntities.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;
using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface ISearchEntities<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Performs a series of filters and/or joins on an entity against a collection.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity}"/> that contains a query expression.</param>
        /// <returns>A <see cref="List{T}"/>.</returns>
        List<TEntity> SearchEntities(IQuery<TEntity> queryObject);
    }
}