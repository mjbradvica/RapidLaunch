﻿// <copyright file="IGetById.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can retrieve a single entity by an identifier.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IGetById<out TEntity, in TId>
        where TEntity : IAggregateRoot<TId>
    {
        /// <summary>
        /// Retrieves an entity from a collection by an identifier.
        /// </summary>
        /// <param name="id">The identifier for the entity.</param>
        /// <returns>The entity returned from the query.</returns>
        TEntity? GetById(TId id);
    }
}