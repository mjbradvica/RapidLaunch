// <copyright file="IAggregateRoot.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace RapidLaunch.Common
{
    /// <summary>
    /// Interface constraint for aggregate roots.
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IAggregateRoot<out TId> : IEntity<TId>
    {
        /// <summary>
        /// Gets an enumerable list of <see cref="IDomainEvent"/>.
        /// </summary>
        IEnumerable<IDomainEvent> DomainEvents { get; }
    }
}
