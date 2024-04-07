// <copyright file="IGetAllEntities.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;
using ClearDomain.Common;

namespace RapidLaunch
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IGetAllEntities<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Retrieves all entities of type from a collection.
        /// </summary>
        /// <returns>An of <see cref="IReadOnlyList{TEntity}"/>.</returns>
        List<TEntity> GetAllEntities();
    }
}