// <copyright file="IDeleteEntityAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can delete an entity asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IDeleteEntityAsync<in TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Removes an entity from a collection asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> DeleteEntityAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
