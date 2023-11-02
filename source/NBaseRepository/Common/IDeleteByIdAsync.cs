// <copyright file="IDeleteByIdAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

namespace NBaseRepository.Common
{
    /// <summary>
    /// An interface used to describe a class that can delete an entity by an identifier asynchronously.
    /// </summary>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IDeleteByIdAsync<in TId>
        where TId : struct
    {
        /// <summary>
        /// Removes an entity from a collection by an identifier.
        /// </summary>
        /// <param name="id">The identifier used to delete the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> DeleteByIdAsync(TId id, CancellationToken cancellationToken);
    }
}
