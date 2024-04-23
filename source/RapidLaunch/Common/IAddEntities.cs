// <copyright file="IAddEntities.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;
using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can add multiple entities at one time.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IAddEntities<in TEntity, TId>
        where TEntity : IAggregateRoot<TId>
    {
        /// <summary>
        /// Adds multiple entities to a collection.
        /// </summary>
        /// <param name="entities">A <see cref="IEnumerable{TEntity}"/> to be added.</param>
        /// <returns>The result contains the number of state entries written to the database.</returns>
        RapidLaunchStatus AddEntities(IEnumerable<TEntity> entities);
    }
}