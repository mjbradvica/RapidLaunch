// <copyright file="NBaseCoreRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NBaseRepository.Common;

namespace NBaseRepository.ADO.Common
{
    public abstract class NBaseCoreRepository<TEntity, TId> :
        IAddEntities<TEntity, TId>,
        IAddEntitiesAsync<TEntity, TId>,
        IAddEntity<TEntity, TId>,
        IAddEntityAsync<TEntity, TId>,
        IDeleteById<TId>,
        IDeleteByIdAsync<TId>,
        IDeleteEntities<TEntity, TId>,
        IDeleteEntitiesAsync<TEntity, TId>,
        IDeleteEntity<TEntity, TId>,
        IDeleteEntityAsync<TEntity, TId>,
        IGetAllEntities<TEntity, TId>,
        IGetAllEntitiesAsync<TEntity, TId>,
        IGetById<TEntity, TId>,
        IGetByIdAsync<TEntity, TId>,
        IUpdateEntities<TEntity, TId>,
        IUpdateEntityAsync<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        private readonly SqlConnection _sqlConnection;
        private readonly SqlBuilder<TEntity, TId> _sqlBuilder;
        private readonly Func<SqlDataReader, TEntity> _conversionFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseCoreRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="conversionFunc">A conversion function to dictate how a result set should be interpreted.</param>
        protected NBaseCoreRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, TId> sqlBuilder, Func<SqlDataReader, TEntity> conversionFunc)
        {
            _sqlConnection = sqlConnection;
            _sqlBuilder = sqlBuilder;
            _conversionFunc = conversionFunc;
        }

        /// <inheritdoc/>
        public virtual int AddEntities(IEnumerable<TEntity> entities)
        {
            return ExecuteNonQuery(_sqlBuilder.InsertMultiple(entities).SqlStatement);
        }

        /// <inheritdoc/>
        public virtual async Task<int> AddEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return await ExecuteNonQueryAsync(_sqlBuilder.InsertMultiple(entities).SqlStatement, cancellationToken);
        }

        /// <inheritdoc/>
        public virtual int AddEntity(TEntity entity)
        {
            return ExecuteNonQuery(_sqlBuilder.Insert(entity).SqlStatement);
        }

        /// <inheritdoc/>
        public virtual async Task<int> AddEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return await ExecuteNonQueryAsync(_sqlBuilder.Insert(entity).SqlStatement, cancellationToken);
        }

        /// <inheritdoc/>
        public virtual int DeleteById(TId id)
        {
            return ExecuteNonQuery(_sqlBuilder.DeleteById(id).SqlStatement);
        }

        /// <inheritdoc/>
        public virtual async Task<int> DeleteByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return await ExecuteNonQueryAsync(_sqlBuilder.DeleteById(id).SqlStatement, cancellationToken);
        }

        /// <inheritdoc/>
        public virtual int DeleteEntities(IEnumerable<TEntity> entities)
        {
            return ExecuteNonQuery(_sqlBuilder.DeleteMultiple(entities).SqlStatement);
        }

        /// <inheritdoc/>
        public virtual async Task<int> DeleteEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            return await ExecuteNonQueryAsync(_sqlBuilder.DeleteMultiple(entities).SqlStatement, cancellationToken);
        }

        /// <inheritdoc/>
        public virtual int DeleteEntity(TEntity entity)
        {
            return ExecuteNonQuery(_sqlBuilder.Delete(entity).SqlStatement);
        }

        /// <inheritdoc/>
        public virtual async Task<int> DeleteEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return await ExecuteNonQueryAsync(_sqlBuilder.Delete(entity).SqlStatement, cancellationToken);
        }

        /// <inheritdoc/>
        public virtual IReadOnlyList<TEntity> GetAllEntities()
        {
            return ExecuteQuery(_sqlBuilder.SelectAll().SqlStatement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conversionFunc"></param>
        /// <returns></returns>
        public virtual IReadOnlyList<TEntity> GetAllEntities(Func<SqlDataReader, TEntity> conversionFunc)
        {
            return ExecuteQuery(_sqlBuilder.SelectAll().SqlStatement, conversionFunc);
        }

        /// <inheritdoc/>
        public virtual async Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(_sqlBuilder.SelectAll().SqlStatement, default, cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conversionFunc"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(Func<SqlDataReader, TEntity> conversionFunc, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(_sqlBuilder.SelectAll().SqlStatement, conversionFunc, cancellationToken);
        }

        /// <inheritdoc/>
        public virtual TEntity GetById(TId id)
        {
            return ExecuteQuery(_sqlBuilder.GetById(id).SqlStatement).First();
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return (await ExecuteQueryAsync(_sqlBuilder.GetById(id).SqlStatement, default, cancellationToken)).First();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conversionFunc"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<TEntity> GetByIdAsync(TId id, Func<SqlDataReader, TEntity> conversionFunc, CancellationToken cancellationToken = default)
        {
            return (await ExecuteQueryAsync(_sqlBuilder.GetById(id).SqlStatement, conversionFunc, cancellationToken)).First();
        }

        /// <inheritdoc/>
        public virtual int UpdateEntities(IEnumerable<TEntity> entities)
        {
            return ExecuteNonQuery(_sqlBuilder.UpdateMultiple(entities, GetColumnNames()).SqlStatement);
        }

        /// <inheritdoc/>
        public virtual async Task<int> UpdateEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var columnNames = await GetColumnNamesAsync(cancellationToken);

            return await ExecuteNonQueryAsync(_sqlBuilder.Update(entity, columnNames).SqlStatement, cancellationToken);
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
        /// <param name="overloadDefaultConversion">An overload to use a custom custom function.</param>
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

        private IEnumerable<string> GetColumnNames()
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

        private async Task<IList<string>> GetColumnNamesAsync(CancellationToken cancellationToken = default)
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
