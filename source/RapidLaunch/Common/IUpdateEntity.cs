// <copyright file="IUpdateEntity.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
	/// <summary>
	/// An interface used to describe a class that can update an entity.
	/// </summary>
	/// <typeparam name="TRoot">The type of the entity.The type of the entity.</typeparam>
	/// <typeparam name="TId">The type of the identifier.</typeparam>
	public interface IUpdateEntity<in TRoot, TId>
        where TRoot : IAggregateRoot<TId>
    {
        /// <summary>
        /// Updates a root in a collection.
        /// </summary>
        /// <param name="root">An updated version of the root.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> indicating the status of the operation.</returns>
        RapidLaunchStatus UpdateEntity(TRoot root);
    }
}