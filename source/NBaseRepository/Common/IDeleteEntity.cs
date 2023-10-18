// <copyright file="IDeleteEntity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace NBaseRepository.Common
{
    /// <summary>
    /// An interface used to describe a class that can delete an entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IDeleteEntity<in TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Removes an <see cref="TEntity"/> from a collection.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be deleted.</param>
        /// <returns>A <see cref="int"/> that contains the number of state entries deleted from the database.</returns>
        int DeleteEntity(TEntity entity);
    }
}