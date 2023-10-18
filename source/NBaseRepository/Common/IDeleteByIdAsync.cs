// <copyright file="IDeleteByIdAsync.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Common
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An interface used to describe a class that can delete an entity by <see cref="TId"/>.
    /// </summary>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IDeleteByIdAsync<in TId>
        where TId : struct
    {
        /// <summary>
        /// Removes an entity from a collection by <see cref="TId"/>.
        /// </summary>
        /// <param name="id">The <see cref="TId"/> used to delete the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> DeleteByIdAsync(TId id, CancellationToken cancellationToken);
    }
}
