// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using Dapper;
using Microsoft.Data.SqlClient;

namespace RapidLaunch.Dapper.Common
{
    /// <summary>
    /// Common functions for all base RapidLaunch repositories.
    /// </summary>
    /// <typeparam name="TRoot">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public abstract class RapidLaunchRepository<TRoot, TId>
        where TRoot : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="connection">An instance of the <see cref="SqlConnection"/> class.</param>
        protected RapidLaunchRepository(SqlConnection connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// Gets the <see cref="SqlConnection"/> instance.
        /// </summary>
        protected SqlConnection Connection { get; }

        /// <summary>
        ///
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<IEnumerable<TRoot>> DoSomething()
        {
            return await ExecuteQueryAsync(
                MappingFuncDefinitions.FirstMappingFuncAsync<TRoot, TRoot>(first => first),
                string.Empty,
                CancellationToken.None);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        protected async Task<TRoot> QuerySingle(string sql, CancellationToken cancellationToken = default)
        {
            await Connection.OpenAsync(cancellationToken);

            var root = await Connection.QuerySingleAsync<TRoot>(sql);

            await Connection.CloseAsync();

            return root;
        }

        /// <summary>
        /// Executes a query against the persistence.
        /// </summary>
        /// <param name="queryFunc"></param>
        /// <param name="sql">The <see cref="string"/> sql to be executed.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="List{T}"/> representing the asynchronous operation.</returns>
        protected virtual async Task<List<TRoot>> ExecuteQueryAsync(Func<SqlConnection, string, Task<IEnumerable<TRoot>>> queryFunc, string sql, CancellationToken cancellationToken)
        {
            await Connection.OpenAsync(cancellationToken);

            var entities = await queryFunc.Invoke(Connection, sql);

            await Connection.CloseAsync();

            return entities.ToList();
        }
    }
}
