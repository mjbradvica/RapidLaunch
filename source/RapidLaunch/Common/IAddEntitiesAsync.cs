﻿// <copyright file="IAddEntitiesAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can add multiple entities at one time.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Identifier.</typeparam>
    public interface IAddEntitiesAsync<in TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Adds multiple entities to a collection.
        /// </summary>
        /// <param name="entities">A <see cref="IEnumerable{TEntity}"/> to be added.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> AddEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}