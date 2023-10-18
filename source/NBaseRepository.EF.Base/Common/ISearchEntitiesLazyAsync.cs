// <copyright file="ISearchEntitiesLazyAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBaseRepository.Common;

namespace NBaseRepository.EF.Base.Common
{
    public interface ISearchEntitiesLazyAsync<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="queryObject"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<TEntity>> SearchEntitiesLazyAsync(IQuery<TEntity> queryObject);

        /// <summary>
        ///
        /// </summary>
        /// <param name="queryObject"></param>
        /// <param name="includeFunc"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<TEntity>> SearchEntitiesLazyAsync(IQuery<TEntity> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}
