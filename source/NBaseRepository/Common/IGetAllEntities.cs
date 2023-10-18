// <copyright file="IGetAllEntities.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace NBaseRepository.Common
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all entities of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IGetAllEntities<out TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from a collection.
        /// </summary>
        /// <returns>A of <see cref="IReadOnlyList{TEntity}"/>.</returns>
        IReadOnlyList<TEntity> GetAllEntities();
    }
}