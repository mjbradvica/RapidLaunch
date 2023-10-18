// <copyright file="IUpdateEntities.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Common
{
    using System.Collections.Generic;

    /// <summary>
    /// An interface used to describe a class that can update a range of entities of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IUpdateEntities<in TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Updates a range <see cref="TEntity"/> in a collection.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to be updated.</param>
        /// <returns>A <see cref="int"/> that contains the number of state entries updated in the database.</returns>
        int UpdateEntities(IEnumerable<TEntity> entities);
    }
}