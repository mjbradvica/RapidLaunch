// <copyright file="IDeleteById.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace NBaseRepository.Common
{
    /// <summary>
    /// An interface used to describe a class that can delete an entity by an identifier.
    /// </summary>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IDeleteById<in TId>
    {
        /// <summary>
        /// Removes an entity from a collection by an identifier.
        /// </summary>
        /// <param name="id">The identifier used to delete the entity.</param>
        /// <returns>An <see cref="int"/> result containing the number of state entries deleted from the database.</returns>
        int DeleteById(TId id);
    }
}