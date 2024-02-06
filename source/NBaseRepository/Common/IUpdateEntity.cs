// <copyright file="IUpdateEntity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace NBaseRepository.Common
{
    /// <summary>
    /// An interface used to describe a class that can update an entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.The type of the Id.</typeparam>
    public interface IUpdateEntity<in TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Updates an entity in a collection.
        /// </summary>
        /// <param name="entity">An updated version of the entity.</param>
        /// <returns>A <see cref="int"/> that contains the number of state entries updated in the database.</returns>
        int UpdateEntity(TEntity entity);
    }
}