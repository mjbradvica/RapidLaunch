// <copyright file="IUpdateEntityAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

namespace NBaseRepository.Common
{
    /// <summary>
    /// An interface used to describe a class that can update an entity asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.The type of the Id.</typeparam>
    public interface IUpdateEntityAsync<in TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Updates an entity in a collection.
        /// </summary>
        /// <param name="entity">An updated version of the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> UpdateEntityAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
