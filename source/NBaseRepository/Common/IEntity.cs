// <copyright file="IEntity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace NBaseRepository.Common
{
    /// <summary>
    /// An interface used to describe a class that has an identifier.
    /// </summary>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IEntity<out TId>
    {
        /// <summary>
        /// Gets the Id of the entity.
        /// </summary>
        TId Id { get; }
    }
}
