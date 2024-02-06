// <copyright file="IUpdateEntities.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace NBaseRepository.Common
{
    /// <summary>
    /// An interface used to describe a class that can update a range of entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IUpdateEntities<in TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Updates a range of entities in a collection.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to be updated.</param>
        /// <returns>A <see cref="int"/> that contains the number of state entries updated in the database.</returns>
        int UpdateEntities(IEnumerable<TEntity> entities);
    }
}