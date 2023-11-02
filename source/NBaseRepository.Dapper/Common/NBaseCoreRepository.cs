// <copyright file="NBaseCoreRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using NBaseRepository.Common;

namespace NBaseRepository.Dapper.Common
{
    /// <summary>
    /// Base core repository for Dapper.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the entity identifier.</typeparam>
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
        private readonly Func<SqlConnection, string, IEnumerable<TEntity>> _executionFunc;
        private readonly Func<SqlConnection, string, Task<IEnumerable<TEntity>>> _asyncExecutionFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseCoreRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity, TId}"/> base class.</param>
        /// <param name="executionFunc">An execution func for synchronous operations.</param>
        /// <param name="asyncExecutionFunc">An execution func for asynchronous operations.</param>
        protected NBaseCoreRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<SqlConnection, string, IEnumerable<TEntity>> executionFunc,
            Func<SqlConnection, string, Task<IEnumerable<TEntity>>> asyncExecutionFunc)
        {
            SqlBuilder = sqlBuilder;
            _sqlConnection = sqlConnection;
            _executionFunc = executionFunc;
            _asyncExecutionFunc = asyncExecutionFunc;
        }

        /// <summary>
        /// Gets the <see cref="SqlBuilder{TEntity, TId}"/>.
        /// </summary>
        protected SqlBuilder<TEntity, TId> SqlBuilder { get; }

        /// <inheritdoc/>
        public virtual int AddEntities(IEnumerable<TEntity> entities)
        {
            return ExecuteNonQuery(SqlBuilder.InsertMultiple(entities).SqlStatement);
        }

        /// <inheritdoc/>
        public virtual async Task<int> AddEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return await ExecuteNonQueryAsync(SqlBuilder.InsertMultiple(entities).SqlStatement, cancellationToken);
        }

        /// <inheritdoc/>
        public virtual int AddEntity(TEntity entity)
        {
            return ExecuteNonQuery(SqlBuilder.Insert(entity).SqlStatement);
        }

        /// <inheritdoc/>
        public virtual async Task<int> AddEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return await ExecuteNonQueryAsync(SqlBuilder.Insert(entity).SqlStatement, cancellationToken);
        }

        /// <inheritdoc/>
        public virtual int DeleteById(TId id)
        {
            return ExecuteNonQuery(SqlBuilder.DeleteById(id).SqlStatement);
        }

        /// <inheritdoc/>
        public virtual async Task<int> DeleteByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return await ExecuteNonQueryAsync(SqlBuilder.DeleteById(id).SqlStatement, cancellationToken);
        }

        /// <inheritdoc/>
        public virtual int DeleteEntities(IEnumerable<TEntity> entities)
        {
            return ExecuteNonQuery(SqlBuilder.DeleteMultiple(entities).SqlStatement);
        }

        /// <inheritdoc/>
        public virtual async Task<int> DeleteEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            return await ExecuteNonQueryAsync(SqlBuilder.DeleteMultiple(entities).SqlStatement, cancellationToken);
        }

        /// <inheritdoc/>
        public virtual int DeleteEntity(TEntity entity)
        {
            return ExecuteNonQuery(SqlBuilder.Delete(entity).SqlStatement);
        }

        /// <inheritdoc/>
        public virtual async Task<int> DeleteEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return await ExecuteNonQueryAsync(SqlBuilder.Delete(entity).SqlStatement, cancellationToken);
        }

        /// <inheritdoc/>
        public virtual IReadOnlyList<TEntity> GetAllEntities()
        {
            return ExecuteQuery(SqlBuilder.SelectAll().SqlStatement).ToList();
        }

        /// <summary>
        /// Retrieves all entities using a custom conversion func.
        /// </summary>
        /// <typeparam name="TFirst">The type of object dapper is mapping to.</typeparam>
        /// <param name="conversionFunc">A conversion func from an object to an entity.</param>
        /// <returns>A <see cref="IReadOnlyList{TEntity}"/>.</returns>
        public virtual IReadOnlyList<TEntity> GetAllEntities<TFirst>(Func<TFirst, TEntity> conversionFunc)
        {
            return ExecuteQuery(SqlBuilder.SelectAll().SqlStatement, MappingFuncDefinitions.FirstMappingFunc(conversionFunc)).ToList();
        }

        /// <inheritdoc/>
        public virtual async Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return (await ExecuteQueryAsync(SqlBuilder.SelectAll().SqlStatement, default, cancellationToken)).ToList();
        }

        /// <summary>
        /// Retrieves all entities asynchronously using a custom conversion func.
        /// </summary>
        /// <typeparam name="TFirst">The type of object dapper is mapping to.</typeparam>
        /// <param name="conversionFunc">A conversion func from the dapper mapped object to the entity desired.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyList{TEntity}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync<TFirst>(Func<TFirst, TEntity> conversionFunc, CancellationToken cancellationToken = default)
        {
            return (await ExecuteQueryAsync(SqlBuilder.SelectAll().SqlStatement, MappingFuncDefinitions.FirstMappingFuncAsync(conversionFunc), cancellationToken)).ToList();
        }

        /// <inheritdoc/>
        public virtual TEntity GetById(TId id)
        {
            return ExecuteQuery(SqlBuilder.GetById(id).SqlStatement).First();
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return (await ExecuteQueryAsync(SqlBuilder.GetById(id).SqlStatement, default, cancellationToken)).First();
        }

        /// <summary>
        /// Retrieves an entity by its identifier given a custom conversion function.
        /// </summary>
        /// <param name="id">The identifier for the entity.</param>
        /// <param name="conversionFunc">A custom conversion function to map a result set.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public virtual async Task<TEntity> GetByIdAsync(TId id, Func<SqlConnection, string, Task<IEnumerable<TEntity>>> conversionFunc, CancellationToken cancellationToken = default)
        {
            return (await ExecuteQueryAsync(SqlBuilder.GetById(id).SqlStatement, conversionFunc, cancellationToken)).First();
        }

        /// <inheritdoc/>
        public virtual int UpdateEntities(IEnumerable<TEntity> entities)
        {
            return ExecuteNonQuery(SqlBuilder.UpdateMultiple(entities, GetColumnNames()).SqlStatement);
        }

        /// <inheritdoc/>
        public virtual async Task<int> UpdateEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var columnNames = await GetColumnNamesAsync(cancellationToken);

            return await ExecuteNonQueryAsync(SqlBuilder.Update(entity, columnNames).SqlStatement, cancellationToken);
        }

        private async Task<int> ExecuteNonQueryAsync(string sql, CancellationToken cancellationToken = default)
        {
            int result;
            DbTransaction? transaction = null;

            try
            {
                await _sqlConnection.OpenAsync(cancellationToken);

                transaction = await _sqlConnection.BeginTransactionAsync(cancellationToken);

                result = await _sqlConnection.ExecuteAsync(sql, null, transaction);

                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                if (transaction != null)
                {
                    await transaction.RollbackAsync(cancellationToken);
                }

                throw;
            }
            finally
            {
                await _sqlConnection.CloseAsync();
            }

            return result;
        }

        private int ExecuteNonQuery(string sql)
        {
            int result;
            DbTransaction? transaction = null;

            try
            {
                _sqlConnection.Open();

                transaction = _sqlConnection.BeginTransaction();

                result = _sqlConnection.Execute(sql, null, transaction);

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

        private async Task<IEnumerable<TEntity>> ExecuteQueryAsync(string sql, Func<SqlConnection, string, Task<IEnumerable<TEntity>>>? asyncExecutionFunc = default, CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> result;

            try
            {
                await _sqlConnection.OpenAsync(cancellationToken);

                if (asyncExecutionFunc != null)
                {
                    result = await asyncExecutionFunc.Invoke(_sqlConnection, sql);
                }
                else
                {
                    result = await _asyncExecutionFunc.Invoke(_sqlConnection, sql);
                }
            }
            finally
            {
                await _sqlConnection.CloseAsync();
            }

            return result;
        }

        private IEnumerable<TEntity> ExecuteQuery(string sql, Func<SqlConnection, string, IEnumerable<TEntity>>? executionFunc = default)
        {
            IEnumerable<TEntity> result;

            try
            {
                _sqlConnection.Open();

                if (executionFunc != null)
                {
                    result = executionFunc.Invoke(_sqlConnection, sql);
                }
                else
                {
                    result = _executionFunc.Invoke(_sqlConnection, sql);
                }
            }
            finally
            {
                _sqlConnection.Close();
            }

            return result;
        }

        private IEnumerable<string> GetColumnNames()
        {
            var sqlQuery = new SqlCommand(SqlBuilder.GetColumnNames().SqlStatement, _sqlConnection);

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
            var sqlQuery = new SqlCommand(SqlBuilder.GetColumnNames().SqlStatement, _sqlConnection);

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

    /// <summary>
    /// Base core Repository for Dapper that uses one return object.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped object from dapper.</typeparam>
    /// <typeparam name="TEntity">The type of the entity for operations.</typeparam>
    /// <typeparam name="TId">The type of the entities identifier.</typeparam>
    public abstract class NBaseCoreRepository<TFirst, TEntity, TId> : NBaseCoreRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseCoreRepository{TFirst, TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping function that converts a series of objects into a entity.</param>
        protected NBaseCoreRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                MappingFuncDefinitions.FirstMappingFunc(mappingFunc),
                MappingFuncDefinitions.FirstMappingFuncAsync(mappingFunc))
        {
        }
    }

    /// <summary>
    /// Base core Repository for Dapper that uses two return objects.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped object from dapper.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped object from dapper.</typeparam>
    /// <typeparam name="TEntity">The type of the entity for operations.</typeparam>
    /// <typeparam name="TId">The type of the entities identifier.</typeparam>
    public abstract class NBaseCoreRepository<TFirst, TSecond, TEntity, TId> : NBaseCoreRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseCoreRepository{TFirst, TSecond, TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping function that converts a series of objects into an entity.</param>
        protected NBaseCoreRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                MappingFuncDefinitions.SecondMappingFunc(mappingFunc),
                MappingFuncDefinitions.SecondMappingFuncAsync(mappingFunc))
        {
        }
    }

    /// <summary>
    /// Base core Repository for Dapper that uses three return objects.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped object from dapper.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped object from dapper.</typeparam>
    /// <typeparam name="TThird">The type of the third mapped object from dapper.</typeparam>
    /// <typeparam name="TEntity">The type of the entity for operations.</typeparam>
    /// <typeparam name="TId">The type of the entities identifier.</typeparam>
    public abstract class NBaseCoreRepository<TFirst, TSecond, TThird, TEntity, TId> : NBaseCoreRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseCoreRepository{TFirst, TSecond, TThird, TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping function that converts a series of objects into the desired entity.</param>
        protected NBaseCoreRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TThird, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                MappingFuncDefinitions.ThirdMappingFunc(mappingFunc),
                MappingFuncDefinitions.ThirdMappingFuncAsync(mappingFunc))
        {
        }
    }

    /// <summary>
    /// Base core Repository for Dapper that uses four return objects.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped object from dapper.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped object from dapper.</typeparam>
    /// <typeparam name="TThird">The type of the third mapped object from dapper.</typeparam>
    /// <typeparam name="TFourth">The type of the fourth mapped object from dapper.</typeparam>
    /// <typeparam name="TEntity">The type of the entity for operations.</typeparam>
    /// <typeparam name="TId">The type of the entities identifier.</typeparam>
    public abstract class NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TEntity, TId> : NBaseCoreRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseCoreRepository{TFirst, TSecond, TThird, TFourth, TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping function that converts a series of objects into an entity.</param>
        protected NBaseCoreRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TThird, TFourth, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                MappingFuncDefinitions.FourthMappingFunc(mappingFunc),
                MappingFuncDefinitions.FourthMappingFuncAsync(mappingFunc))
        {
        }
    }

    /// <summary>
    /// Base core Repository for Dapper that uses five return objects.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped object from dapper.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped object from dapper.</typeparam>
    /// <typeparam name="TThird">The type of the third mapped object from dapper.</typeparam>
    /// <typeparam name="TFourth">The type of the fourth mapped object from dapper.</typeparam>
    /// <typeparam name="TFifth">The type of the fifth mapped object from dapper.</typeparam>
    /// <typeparam name="TEntity">The type of the entity for operations.</typeparam>
    /// <typeparam name="TId">The type of the entities identifier.</typeparam>
    public abstract class NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TEntity, TId> : NBaseCoreRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseCoreRepository{TFirst, TSecond, TThird, TFourth, TFifth, TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping function that converts a series of objects into an entity.</param>
        protected NBaseCoreRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                MappingFuncDefinitions.FifthMappingFunc(mappingFunc),
                MappingFuncDefinitions.FifthMappingFuncAsync(mappingFunc))
        {
        }
    }

    /// <summary>
    /// Base core Repository for Dapper that uses six return objects.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped object from dapper.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped object from dapper.</typeparam>
    /// <typeparam name="TThird">The type of the third mapped object from dapper.</typeparam>
    /// <typeparam name="TFourth">The type of the fourth mapped object from dapper.</typeparam>
    /// <typeparam name="TFifth">The type of the fifth mapped object from dapper.</typeparam>
    /// <typeparam name="TSixth">The type of the sixth mapped object from dapper.</typeparam>
    /// <typeparam name="TEntity">The type of the entity for operations.</typeparam>
    /// <typeparam name="TId">The type of the entities identifier.</typeparam>
    public abstract class NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity, TId> : NBaseCoreRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseCoreRepository{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping function that converts a series of objects into an entity.</param>
        protected NBaseCoreRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                MappingFuncDefinitions.SixthMappingFunc(mappingFunc),
                MappingFuncDefinitions.SixthMappingFuncAsync(mappingFunc))
        {
        }
    }

    /// <summary>
    /// Base core Repository for Dapper that uses seven return objects.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped object from dapper.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped object from dapper.</typeparam>
    /// <typeparam name="TThird">The type of the third mapped object from dapper.</typeparam>
    /// <typeparam name="TFourth">The type of the fourth mapped object from dapper.</typeparam>
    /// <typeparam name="TFifth">The type of the fifth mapped object from dapper.</typeparam>
    /// <typeparam name="TSixth">The type of the sixth mapped object from dapper.</typeparam>
    /// <typeparam name="TSeventh">The type of the seventh mapped object from dapper.</typeparam>
    /// <typeparam name="TEntity">The type of the entity for operations.</typeparam>
    /// <typeparam name="TId">The type of the entities identifier.</typeparam>
    public abstract class NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity, TId> : NBaseCoreRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseCoreRepository{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping function that converts a series of objects into an entity.</param>
        protected NBaseCoreRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                MappingFuncDefinitions.SeventhMappingFunc(mappingFunc),
                MappingFuncDefinitions.SeventhMappingFuncAsync(mappingFunc))
        {
        }
    }
}
