// <copyright file="RapidLaunchRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;
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
        /// <param name="command">The sql command to execute.</param>
        /// <param name="postOperationFunc">A <see cref="Func{TResult}"/> to run post operation effects.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> that indicates the number of rows affected.</returns>
        protected virtual RapidLaunchStatus ExecuteCommand(string command, Func<int, IEnumerable<IAggregateRoot<TId>>, Task>? postOperationFunc = default)
        {
            int result;

            SqlTransaction? transaction = null;

            try
            {
                _sqlConnection.Open();

                transaction = _sqlConnection.BeginTransaction();

                var sqlCommand = new SqlCommand(command, _sqlConnection);

                result = sqlCommand.ExecuteNonQuery();

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
        /// <param name="command">The sql command to execute.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <param name="postOperationFunc">A <see cref="Func{TResult}"/> to run post operation effects.</param>
        /// <returns>A <see cref="Task{TResult}"/> of type <see cref="RapidLaunchStatus"/> representing the result of the asynchronous operation.</returns>
        protected virtual async Task<RapidLaunchStatus> ExecuteCommandAsync(string command, CancellationToken cancellationToken, Func<int, IEnumerable<IAggregateRoot<TId>>, Task>? postOperationFunc = default)
        {
            int result;

            await _sqlConnection.OpenAsync(cancellationToken);

            var transaction = _sqlConnection.BeginTransaction();

            var sqlCommand = new SqlCommand(command, _sqlConnection, transaction);

            try
            {
                result = await sqlCommand.ExecuteNonQueryAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                await transaction.RollbackAsync(cancellationToken);

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
        /// <param name="postExecutionFunc">A <see cref="Func{TResult}"/> to modify the result set if required.</param>
        /// <returns>A <see cref="Task{TResult}"/> of type <see cref="List{TResult}"/> representing the result of the asynchronous operation.</returns>
        protected virtual List<TEntity> ExecuteQuery(string command, Func<SqlDataReader, TEntity>? overloadDefaultConversion = default, Func<List<TEntity>, List<TEntity>>? postExecutionFunc = default)
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

            if (postExecutionFunc != null)
            {
                return postExecutionFunc.Invoke(result);
            }

            return result;
        }

        /// <summary>
        /// Executes a query asynchronously.
        /// </summary>
        /// <param name="command">The sql command to execute.</param>
        /// <param name="overloadDefaultConversion">An overload to use a custom conversion function.</param>
        /// /// <param name="postExecutionFunc">A <see cref="Func{TResult}"/> to modify the result set if required.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> of type <see cref="List{TResult}"/> representing the result of the asynchronous operation.</returns>
        protected virtual async Task<List<TEntity>> ExecuteQueryAsync(string command, Func<SqlDataReader, TEntity>? overloadDefaultConversion = default, Func<List<TEntity>, List<TEntity>>? postExecutionFunc = default, CancellationToken cancellationToken = default)
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

            if (postExecutionFunc != null)
            {
                return postExecutionFunc.Invoke(result);
            }

            return result;
        }

        // TODO: Condense using the ExecuteQuery method.
        private List<string> GetColumnNames()
        {
            if (_sqlBuilder.ColumnNames != null)
            {
                return _sqlBuilder.ColumnNames.ToList();
            }

            var sqlQuery = new SqlCommand(_sqlBuilder.GetColumnNames().SqlStatement, _sqlConnection);

            _sqlConnection.Open();

            var sqlDataReader = sqlQuery.ExecuteReader();

            var result = new List<string>();

            while (sqlDataReader.Read())
            {
                result.Add(sqlDataReader.GetString(0));
            }

            _sqlConnection.Close();

            _sqlBuilder.UpdateColumnNames(result);

            return result;
        }

        // TODO: Condense using the ExecuteQuery method.
        private async Task<List<string>> GetColumnNamesAsync(CancellationToken cancellationToken = default)
        {
            if (_sqlBuilder.ColumnNames != null)
            {
                return _sqlBuilder.ColumnNames.ToList();
            }

            var sqlQuery = new SqlCommand(_sqlBuilder.GetColumnNames().SqlStatement, _sqlConnection);

            await _sqlConnection.OpenAsync(cancellationToken);

            var sqlDataReader = await sqlQuery.ExecuteReaderAsync(cancellationToken);

            var result = new List<string>();

            while (await sqlDataReader.ReadAsync(cancellationToken))
            {
                result.Add(sqlDataReader.GetString(0));
            }

            _sqlConnection.Close();

            _sqlBuilder.UpdateColumnNames(result);

            return result;
        }
    }
}
