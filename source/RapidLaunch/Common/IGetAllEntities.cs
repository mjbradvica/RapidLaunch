// <copyright file="IGetAllEntities.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all entities.
    /// </summary>
    /// <typeparam name="TRoot">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IGetAllEntities<TRoot, TId>
        where TRoot : IAggregateRoot<TId>
    {
        /// <summary>
        /// Retrieves all entities of type from a collection.
        /// </summary>
        /// <returns>An of <see cref="List{TEntity}"/>.</returns>
        List<TRoot> GetAllEntities();
    }
}