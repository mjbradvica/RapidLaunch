// <copyright file="IGetEntitiesByIdAsync.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that retrieves entities by an enumerable identifier list.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IGetEntitiesByIdAsync<TEntity, in TId>
        where TEntity : IAggregateRoot<TId>
    {
        /// <summary>
        /// Retrieves a list of entities that match a parameter of identifiers.
        /// </summary>
        /// <param name="identifiers">A <see cref="IEnumerable{T}"/> of identifiers.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="List{T}"/> representing the asynchronous operation.</returns>
        Task<List<TEntity>> GetEntitiesByIdAsync(IEnumerable<TId> identifiers, CancellationToken cancellationToken = default);
    }
}
