// <copyright file="IEntity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that has an identifier.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IEntity<out TId>
    {
        /// <summary>
        /// Gets the identifier of the entity.
        /// </summary>
        TId Id { get; }
    }
}
