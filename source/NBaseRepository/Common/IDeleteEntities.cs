﻿// <copyright file="IDeleteEntities.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace NBaseRepository.Common
{
    /// <summary>
    /// An interface used to describe a class that can delete multiple entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IDeleteEntities<in TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Removes multiple entities from a collection.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to be deleted.</param>
        /// <returns>An <see cref="int"/> that contains the number of state entries deleted from the database.</returns>
        int DeleteEntities(IEnumerable<TEntity> entities);
    }
}