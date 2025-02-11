// <copyright file="IGetAllEntitiesAsync.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all entities asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IGetAllEntitiesAsync<TEntity, TId>
        where TEntity : IAggregateRoot<TId>
    {
        /// <summary>
        /// Retrieves all entities from a collection.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="List{TEntity}"/>.</returns>
        Task<List<TEntity>> GetAllEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
