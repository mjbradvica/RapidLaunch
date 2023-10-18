// <copyright file="IGetAllEntitiesLazyAsync.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.EF.Base.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NBaseRepository.Common;

    public interface IGetAllEntitiesLazyAsync<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<TEntity>> GetAllEntitiesLazyAsync();

        /// <summary>
        ///
        /// </summary>
        /// <param name="includeFunc"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<TEntity>> GetAllEntitiesLazyAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}
