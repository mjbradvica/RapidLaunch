// <copyright file="NBaseCoreRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.ADO.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using NBaseRepository.Common;

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
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="conversionFunc"></param>
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
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
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
        ///
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        protected async Task<int> ExecuteNonQueryAsync(string command, CancellationToken cancellationToken = default)
        {
            int result;

            await _sqlConnection.OpenAsync(cancellationToken);

            var transaction = _sqlConnection.BeginTransaction();

            var sqlCommand = new SqlCommand(command, _sqlConnection, transaction);

            try
            {
                result = await sqlCommand.ExecuteNonQueryAsync(cancellationToken);
#if NETSTANDARD2_0
                transaction.Commit();
#endif

#if NETSTANDARD2_1_OR_GREATER
                await transaction.CommitAsync(cancellationToken);
#endif

#if NET5_0_OR_GREATER
                await transaction.CommitAsync(cancellationToken);
#endif
            }
            catch (Exception)
            {
#if NETSTANDARD2_0
                transaction.Rollback();
#endif

#if NETSTANDARD2_1_OR_GREATER
                await transaction.RollbackAsync(cancellationToken);
#endif

#if NET5_0_OR_GREATER
                await transaction.RollbackAsync(cancellationToken);
#endif

                throw;
            }
            finally
            {
#if NETSTANDARD2_0
                _sqlConnection.Close();
#endif

#if NETSTANDARD2_1_OR_GREATER
                await _sqlConnection.CloseAsync();
#endif

#if NET5_0_OR_GREATER
                await _sqlConnection.CloseAsync();
#endif
            }

            return result;
        }

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
        ///
        /// </summary>
        /// <param name="command"></param>
        /// <param name="overloadDefaultConversion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
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

#if NETSTANDARD2_0
            _sqlConnection.Close();
#endif

#if NETSTANDARD2_1_OR_GREATER
            await _sqlConnection.CloseAsync();
#endif

#if NET5_0_OR_GREATER
            await _sqlConnection.CloseAsync();
#endif

            return result;
        }

        private IEnumerable<string> GetColumnNames()
        {
            var sqlQuery = new SqlCommand(_sqlBuilder.GetColumnNames().SqlStatement, _sqlConnection);

            _sqlConnection.Open();

            var sqlDataReader = sqlQuery.ExecuteReader();

            var result = new List<string>();

            while (sqlDataReader.Read())
            {
                result.Add(sqlDataReader.GetString(0));
            }

            _sqlConnection.Close();

            return result;
        }

        private async Task<List<string>> GetColumnNamesAsync(CancellationToken cancellationToken = default)
        {
            var sqlQuery = new SqlCommand(_sqlBuilder.GetColumnNames().SqlStatement, _sqlConnection);

            await _sqlConnection.OpenAsync(cancellationToken);

            var sqlDataReader = await sqlQuery.ExecuteReaderAsync(cancellationToken);

            var result = new List<string>();

            while (await sqlDataReader.ReadAsync(cancellationToken))
            {
                result.Add(sqlDataReader.GetString(0));
            }

            _sqlConnection.Close();

            return result;
        }
    }
}
