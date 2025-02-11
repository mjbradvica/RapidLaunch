// <copyright file="IGetAllEntitiesLazy.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all entities lazily.
    /// </summary>
    /// <typeparam name="TRoot">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IGetAllEntitiesLazy<out TRoot, TId>
        where TRoot : IAggregateRoot<TId>
    {
        /// <summary>
        /// Retrieves all entities from a collection that may still be queried against.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{TEntity}"/>.</returns>
        IQueryable<TRoot> GetAllEntitiesLazy();
    }
}
