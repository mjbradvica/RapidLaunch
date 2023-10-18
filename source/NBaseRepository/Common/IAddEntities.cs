// <copyright file="IAddEntities.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace NBaseRepository.Common
{
    /// <summary>
    /// An interface used to describe a class that can add multiple entities of type <see cref="TEntity"/> at one time.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IAddEntities<in TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Adds multiple <see cref="TEntity"/>s to a collection.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to be added.</param>
        /// <returns>The result contains the number of state entries written to the database.</returns>
        int AddEntities(IEnumerable<TEntity> entities);
    }
}