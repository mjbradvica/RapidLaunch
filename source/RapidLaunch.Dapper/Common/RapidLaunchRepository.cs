// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;
using Dapper;

namespace RapidLaunch.Dapper.Common
{
    /// <summary>
    /// Common functions for all base RapidLaunch repositories.
    /// </summary>
    /// <typeparam name="TModel">The type of the mapped model.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public abstract class RapidLaunchRepository<TModel, TEntity, TId>
        where TModel : class
        where TEntity : class, IAggregateRoot<TId>
    {
        private readonly Func<TModel, TEntity> _mappingFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TModel, TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="mappingFunc">A <see cref="Func{TResult}"/> that maps the data result to the entity type.</param>
        protected RapidLaunchRepository(SqlConnection sqlConnection, Func<TModel, TEntity> mappingFunc)
        {
            SqlConnection = sqlConnection;
            _mappingFunc = mappingFunc;
        }

        /// <summary>
        /// Gets the current <see cref="SqlConnection"/>.
        /// </summary>
        protected SqlConnection SqlConnection { get; }

        /// <summary>
        /// Executes a query asynchronously.
        /// </summary>
        /// <param name="sql">A <see cref="string"/> that contains the sql query.</param>
        /// <param name="overloadDefaultInclusion">A <see cref="Func{TResult}"/> to overload the default conversion.</param>
        /// /// <param name="postExecutionFunc">A <see cref="Func{TResult}"/> to modify the result set if required.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> of type <see cref="List{TResult}"/> representing the result of the asynchronous operation.</returns>
        protected virtual async Task<List<TEntity>> ExecuteQueryAsync(string sql, Func<TModel, TEntity>? overloadDefaultInclusion = default, Func<List<TEntity>, List<TEntity>>? postExecutionFunc = default, CancellationToken cancellationToken = default)
        {
            await SqlConnection.OpenAsync(cancellationToken);

            var result = await SqlConnection.QueryAsync<TModel>(sql);

            var mapper = overloadDefaultInclusion ?? _mappingFunc;

            var entities = result.Select(mapper).ToList();

            await SqlConnection.CloseAsync();

            if (postExecutionFunc != null)
            {
                return postExecutionFunc.Invoke(entities);
            }

            return entities;
        }
    }
}
