// <copyright file="IGetAllEntitiesLazy.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using NBaseRepository.Common;

namespace NBaseRepository.EF.Base.Common
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all entities lazily.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IGetAllEntitiesLazy<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Retrieves all entities from a collection that may still be queried against.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{TEntity}"/>.</returns>
        IEnumerable<TEntity> GetAllEntitiesLazy();

        /// <summary>
        /// Retrieves all entities from a collection that accepts a custom include func for eager loading that may still be queried against.
        /// </summary>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <returns>An <see cref="IEnumerable{TEntity}"/>.</returns>
        IEnumerable<TEntity> GetAllEntitiesLazy(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}
