// <copyright file="IGetByIdAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

namespace NBaseRepository.Common
{
    /// <summary>
    /// An interface used to describe a class that can retrieve a single entity by an identifier.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IGetByIdAsync<TEntity, in TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Retrieves an entity from a collection by an identifier.
        /// </summary>
        /// <param name="id">The identifier for the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>The desired entity.</returns>
        Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken);
    }
}
