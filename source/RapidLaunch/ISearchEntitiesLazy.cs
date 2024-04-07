// <copyright file="ISearchEntitiesLazy.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using ClearDomain.Common;

namespace RapidLaunch
{
    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins for an entity lazily.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface ISearchEntitiesLazy<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Performs a series of filters and/or joins on an entity against a collection that has not been executed.
        /// </summary>
        /// <param name="queryObject">A query object of type <see cref="IQuery{TEntity}"/> that contains a query expression.</param>
        /// <returns>An <see cref="IEnumerable{TEntity}"/>.</returns>
        IEnumerable<TEntity> SearchEntitiesLazy(IQuery<TEntity> queryObject);

        /// <summary>
        /// Performs a series of filters and/or joins on an entity against a collection that accepts a customer include func that has not been executed.
        /// </summary>
        /// <param name="queryObject">A query object of type <see cref="IQuery{TEntity}"/> that contains a query expression.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <returns>An <see cref="IEnumerable{TEntity}"/>.</returns>
        IEnumerable<TEntity> SearchEntitiesLazy(IQuery<TEntity> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}
