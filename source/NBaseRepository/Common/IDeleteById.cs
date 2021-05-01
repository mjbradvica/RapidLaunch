﻿namespace NBaseRepository.Common
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An interface used to describe a class that can delete an entity by <see cref="TId"/>.
    /// </summary>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IDeleteById<in TId>
    {
        /// <summary>
        /// Removes an entity from a collection by its Id.
        /// </summary>
        /// <param name="id">The Id used to delete the entity.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        Task<int> DeleteById(TId id, CancellationToken cancellationToken);
    }
}
