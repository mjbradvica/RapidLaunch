// <copyright file="IAddEntityAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface that allows a class to add a single entity asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IAddEntityAsync<in TEntity, TId>
        where TEntity : IAggregateRoot<TId>
    {
        /// <summary>
        /// Adds a single entity to a collection.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="RapidLaunchStatus"/> that represents the asynchronous operation.</returns>
        Task<RapidLaunchStatus> AddEntityAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
