// <copyright file="IGetAllEntitiesLazyAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBaseRepository.Common;

namespace NBaseRepository.EF.Base.Common
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all entities lazily and asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IGetAllEntitiesLazyAsync<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Retrieves all entities both lazily and asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> of type <see cref="IEnumerable{T}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<TEntity>> GetAllEntitiesLazyAsync();

        /// <summary>
        /// Retrieves all entities both lazily and asynchronously with a custom conversion function.
        /// </summary>
        /// <param name="includeFunc">A custom include function to load related entities.</param>
        /// <returns>A <see cref="Task{TResult}"/> of type <see cref="IEnumerable{T}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<TEntity>> GetAllEntitiesLazyAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}
