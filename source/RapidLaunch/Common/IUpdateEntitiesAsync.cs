// <copyright file="IUpdateEntitiesAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can update a range of entities asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IUpdateEntitiesAsync<in TEntity, TId>
        where TEntity : IAggregateRoot<TId>
    {
        /// <summary>
        /// Updates a range of entities in a collection.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to be updated.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="RapidLaunchStatus"/> that represents the asynchronous operation.</returns>
        Task<RapidLaunchStatus> UpdateEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
