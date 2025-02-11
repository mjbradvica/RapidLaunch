// <copyright file="RapidLaunchRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System.Data;
using ClearDomain.Common;
using Microsoft.Data.SqlClient;
using RapidLaunch.Common;

namespace RapidLaunch.ADO.Common
{
    /// <summary>
    /// Common functions for all base RapidLaunch repositories.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public abstract class RapidLaunchRepository<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        private readonly SqlConnection _sqlConnection;
        private readonly SqlBuilder<TEntity, TId> _sqlBuilder;
        private readonly Func<SqlDataReader, TEntity> _conversionFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> class.</param>
        /// <param name="conversionFunc">A <see cref="Func{TResult}"/> to convert a <see cref="SqlDataReader"/> to an entity.</param>
        protected RapidLaunchRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, TId> sqlBuilder, Func<SqlDataReader, TEntity> conversionFunc)
        {
            _sqlConnection = sqlConnection;
            _sqlBuilder = sqlBuilder;
            _conversionFunc = conversionFunc;
        }

        /// <summary>
        /// Executes a non-query synchronously.
        /// </summary>
        /// <param name="executionFunc">A <see cref="Func{TResult}"/> that yields a SQL statement and the entities to execute again.</param>
        /// <param name="postOperationFunc">A <see cref="Func{TResult}"/> to run post operation effects.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> that indicates the number of rows affected.</returns>
        protected virtual RapidLaunchStatus ExecuteCommand(Func<(string Command, IEnumerable<TEntity> Entities)> executionFunc, Action<int, IEnumerable<IAggregateRoot<TId>>>? postOperationFunc = default)
        {
            int result;

            SqlTransaction? transaction = null;

            try
            {
                _sqlConnection.Open();

                transaction = _sqlConnection.BeginTransaction();

                var (command, entities) = executionFunc.Invoke();

                var sqlCommand = new SqlCommand(command, _sqlConnection);

                result = sqlCommand.ExecuteNonQuery();

                postOperationFunc?.Invoke(result, entities);

                transaction.Commit();
            }
            catch (Exception exception)
            {
                transaction?.Rollback();

                return RapidLaunchStatus.Failed(exception);
            }
            finally
            {
                _sqlConnection.Close();
            }

            return RapidLaunchStatus.Success(result);
        }

        /// <summary>
        /// Execute a non-query asynchronously.
        /// </summary>
        /// <param name="executionFunc">A <see cref="Func{TResult}"/> that yields a SQL statement and the entities to execute again.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <param name="postOperationFunc">A <see cref="Func{TResult}"/> to run post operation effects.</param>
        /// <returns>A <see cref="Task{TResult}"/> of type <see cref="RapidLaunchStatus"/> representing the result of the asynchronous operation.</returns>
        protected virtual async Task<RapidLaunchStatus> ExecuteCommandAsync(Func<(string Command, IEnumerable<TEntity> Entities)> executionFunc, CancellationToken cancellationToken, Func<int, IEnumerable<IAggregateRoot<TId>>, Task>? postOperationFunc = default)
        {
            int result;

            SqlTransaction? transaction = null;

            try
            {
                await _sqlConnection.OpenAsync(cancellationToken);

                transaction = _sqlConnection.BeginTransaction();

                var (command, entities) = executionFunc.Invoke();

                var sqlCommand = new SqlCommand(command, _sqlConnection, transaction);

                result = await sqlCommand.ExecuteNonQueryAsync(cancellationToken);

                if (postOperationFunc != null)
                {
                    await postOperationFunc.Invoke(result, entities);
                }

                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                if (transaction != null)
                {
                    await transaction.RollbackAsync(cancellationToken);
                }

                return RapidLaunchStatus.Failed(exception);
            }
            finally
            {
                await _sqlConnection.CloseAsync();
            }

            return RapidLaunchStatus.Success(result);
        }

        /// <summary>
        /// Executes a query synchronously.
        /// </summary>
        /// <param name="command">The sql command to execute.</param>
        /// <param name="overloadDefaultConversion">An overload to use a custom function.</param>
        /// <returns>A <see cref="Task{TResult}"/> of type <see cref="List{TResult}"/> representing the result of the asynchronous operation.</returns>
        protected virtual List<TEntity> ExecuteQuery(string command, Func<SqlDataReader, TEntity>? overloadDefaultConversion = default)
        {
            var sqlQuery = new SqlCommand(command, _sqlConnection);

            _sqlConnection.Open();

            var sqlDataReader = sqlQuery.ExecuteReader();

            var result = new List<TEntity>();

            var conversionFunc = overloadDefaultConversion ?? _conversionFunc;

            while (sqlDataReader.Read())
            {
                result.Add(conversionFunc.Invoke(sqlDataReader));
            }

            _sqlConnection.Close();

            return result;
        }

        /// <summary>
        /// Executes a query asynchronously.
        /// </summary>
        /// <param name="command">The sql command to execute.</param>
        /// <param name="overloadDefaultConversion">An overload to use a custom conversion function.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> of type <see cref="List{TResult}"/> representing the result of the asynchronous operation.</returns>
        protected virtual async Task<List<TEntity>> ExecuteQueryAsync(string command, Func<SqlDataReader, TEntity>? overloadDefaultConversion = default, CancellationToken cancellationToken = default)
        {
            var sqlQuery = new SqlCommand(command, _sqlConnection);

            await _sqlConnection.OpenAsync(cancellationToken);

            var sqlDataReader = await sqlQuery.ExecuteReaderAsync(cancellationToken);

            var result = new List<TEntity>();

            var conversionFunc = overloadDefaultConversion ?? _conversionFunc;

            while (await sqlDataReader.ReadAsync(cancellationToken))
            {
                result.Add(conversionFunc.Invoke(sqlDataReader));
            }

            await _sqlConnection.CloseAsync();

            return result;
        }

        /// <summary>
        /// Executes a stored procedure for a query.
        /// </summary>
        /// <param name="procedureName">The name of procedure to run.</param>
        /// <param name="parameters">A <see cref="Dictionary{TKey,TValue}"/> of parameters to pass.</param>
        /// <param name="overloadDefaultConversion">A <see cref="Func{TResult}"/> to overload the data reader.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected virtual async Task<List<TEntity>> ExecuteStoredProcedureQueryAsync(
            string procedureName,
            Dictionary<string, object>? parameters = default,
            Func<SqlDataReader, TEntity>? overloadDefaultConversion = default,
            CancellationToken cancellationToken = default)
        {
            var command = new SqlCommand(procedureName, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }

            await _sqlConnection.OpenAsync(cancellationToken);

            var sqlDataReader = await command.ExecuteReaderAsync(cancellationToken);

            var result = new List<TEntity>();

            var conversionFunc = overloadDefaultConversion ?? _conversionFunc;

            while (await sqlDataReader.ReadAsync(cancellationToken))
            {
                result.Add(conversionFunc.Invoke(sqlDataReader));
            }

            await _sqlConnection.CloseAsync();

            return result;
        }
    }
}
