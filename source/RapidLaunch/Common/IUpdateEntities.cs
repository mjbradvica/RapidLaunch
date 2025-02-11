// <copyright file="IUpdateEntities.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
	/// <summary>
	/// An interface used to describe a class that can update a range of entities.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <typeparam name="TId">The type of the identifier.</typeparam>
	public interface IUpdateEntities<in TEntity, TId>
        where TEntity : IAggregateRoot<TId>
    {
        /// <summary>
        /// Updates a range of entities in a collection.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to be updated.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> that contains the status of the operation.</returns>
        RapidLaunchStatus UpdateEntities(IEnumerable<TEntity> entities);
    }
}