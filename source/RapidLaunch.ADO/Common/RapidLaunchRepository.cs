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

namespace RapidLaunch.ADO.Common
{
    /// <summary>
    /// Common functions for all EF RapidLaunch repositories.
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
        /// <returns>An <see cref="int"/> that indicates the number of rows affected.</returns>
        protected int ExecuteNonQuery(string command)
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
            catch (Exception)
            {
                transaction?.Rollback();

                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }

            return result;
        }

        /// <summary>
        /// Execute a non-query asynchronously.
        /// </summary>
        /// <param name="command">The sql command to execute.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> of type <see cref="int"/> representing the result of the asynchronous operation.</returns>
        protected async Task<int> ExecuteNonQueryAsync(string command, CancellationToken cancellationToken = default)
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
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);

                throw;
            }
            finally
            {
                await _sqlConnection.CloseAsync();
            }

            return result;
        }

        /// <summary>
        /// Executes a query synchronously.
        /// </summary>
        /// <param name="command">The sql command to execute.</param>
        /// <param name="overloadDefaultConversion">An overload to use a custom function.</param>
        /// <returns>A <see cref="Task{TResult}"/> of type <see cref="List{TResult}"/> representing the result of the asynchronous operation.</returns>
        protected List<TEntity> ExecuteQuery(string command, Func<SqlDataReader, TEntity>? overloadDefaultConversion = default)
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
        protected async Task<List<TEntity>> ExecuteQueryAsync(string command, Func<SqlDataReader, TEntity>? overloadDefaultConversion = default, CancellationToken cancellationToken = default)
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
