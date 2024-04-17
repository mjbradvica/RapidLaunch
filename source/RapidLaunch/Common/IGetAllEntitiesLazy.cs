// <copyright file="IGetAllEntitiesLazy.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;
using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all entities lazily.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IGetAllEntitiesLazy<out TEntity, TId>
        where TEntity : IAggregateRoot<TId>
    {
        /// <summary>
        /// Retrieves all entities from a collection that may still be queried against.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{TEntity}"/>.</returns>
        IEnumerable<TEntity> GetAllEntitiesLazy();
    }
}
