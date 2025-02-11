// <copyright file="ISearchEntitiesLazy.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins for an entity lazily.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface ISearchEntitiesLazy<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Performs a series of filters and/or joins on an entity against a collection that has not been executed.
        /// </summary>
        /// <param name="queryObject">A query object of type <see cref="IQuery{TEntity}"/> that contains a query expression.</param>
        /// <returns>An <see cref="IQueryable{TEntity}"/>.</returns>
        IQueryable<TEntity> SearchEntitiesLazy(IQuery<TEntity> queryObject);
    }
}
