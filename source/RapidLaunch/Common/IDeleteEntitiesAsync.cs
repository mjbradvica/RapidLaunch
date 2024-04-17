// <copyright file="IDeleteEntitiesAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can delete multiple entities asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IDeleteEntitiesAsync<in TEntity, TId>
        where TEntity : IAggregateRoot<TId>
    {
        /// <summary>
        /// Removes multiple entities from a collection asynchronously.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="RapidLaunchStatus"/> that represents the asynchronous operation.</returns>
        Task<RapidLaunchStatus> DeleteEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
