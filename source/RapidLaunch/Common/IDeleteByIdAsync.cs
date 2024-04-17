// <copyright file="IDeleteByIdAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can delete an entity by an identifier asynchronously.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IDeleteByIdAsync<in TId>
    {
        /// <summary>
        /// Removes an entity from a collection by an identifier.
        /// </summary>
        /// <param name="id">The identifier used to delete the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="RapidLaunchStatus"/> that represents the asynchronous operation.</returns>
        Task<RapidLaunchStatus> DeleteByIdAsync(TId id, CancellationToken cancellationToken = default);
    }
}
