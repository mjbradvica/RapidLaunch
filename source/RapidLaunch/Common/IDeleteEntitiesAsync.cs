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
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IDeleteEntitiesAsync<in TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Removes multiple entities from a collection asynchronously.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> DeleteEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
