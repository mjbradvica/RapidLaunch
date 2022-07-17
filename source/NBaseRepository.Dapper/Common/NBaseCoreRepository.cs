namespace NBaseRepository.Dapper.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Dapper;
    using NBaseRepository.Common;

    public abstract class NBaseCoreRepository<TEntity, TId> :
        IAddEntities<TEntity, TId>,
        IGetAllEntities<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        private readonly SqlConnection _sqlConnection;
        private readonly Func<SqlConnection, string, IEnumerable<TEntity>> _executionFunc;
        private readonly Func<SqlConnection, string, Task<IEnumerable<TEntity>>> _asyncExecutionFunc;

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

        protected SqlBuilder<TEntity, TId> SqlBuilder { get; }

        public virtual int AddEntities(IEnumerable<TEntity> entities)
        {
            return ExecuteCommand(SqlBuilder.InsertMultiple(entities).SqlStatement);
        }

        public virtual IReadOnlyList<TEntity> GetAllEntities()
        {
            return _sqlConnection.Query<TEntity>(SqlBuilder.SelectAll().SqlStatement).ToList();
        }

        public virtual IReadOnlyList<TEntity> GetAllEntities<TFirst, TSecond, TThird>(Func<TFirst, TSecond, TThird, TEntity> mappingFunc)
        {
            return ExecuteQuery(SqlBuilder.SelectAll().SqlStatement, (connection, s) => connection.Query(s, mappingFunc)).ToList();
        }

        private async Task<int> ExecuteCommandAsync(string sql, CancellationToken cancellationToken = default)
        {
            int result;
            DbTransaction transaction = null;

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

        private int ExecuteCommand(string sql)
        {
            int result;
            DbTransaction transaction = null;

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

        private async Task<IEnumerable<TEntity>> ExecuteQueryAsync(string sql, CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> result;

            try
            {
                await _sqlConnection.OpenAsync(cancellationToken);

                result = await _asyncExecutionFunc.Invoke(_sqlConnection, sql);
            }
            finally
            {
                await _sqlConnection.CloseAsync();
            }

            return result;
        }

        private IEnumerable<TEntity> ExecuteQuery(string sql, Func<SqlConnection, string, IEnumerable<TEntity>> executionFunc = default)
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
    }

    public abstract class NBaseCoreRepository<TFirst, TEntity, TId> : NBaseCoreRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        protected NBaseCoreRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                (connection, sql) => connection.Query<TFirst>(sql).Select(mappingFunc.Invoke),
                async (connection, sql) => (await connection.QueryAsync<TFirst>(sql)).Select(mappingFunc.Invoke))
        {
        }
    }

    public abstract class NBaseCoreRepository<TFirst, TSecond, TEntity, TId> : NBaseCoreRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        protected NBaseCoreRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                (connection, sql) => connection.Query(sql, mappingFunc),
                async (connection, sql) => await connection.QueryAsync(sql, mappingFunc))
        {
        }
    }

    public abstract class NBaseCoreRepository<TFirst, TSecond, TThird, TEntity, TId> : NBaseCoreRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        protected NBaseCoreRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TThird, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                (connection, sql) => connection.Query(sql, mappingFunc),
                async (connection, sql) => await connection.QueryAsync(sql, mappingFunc))
        {
        }
    }

    public abstract class NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TEntity, TId> : NBaseCoreRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        protected NBaseCoreRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TThird, TFourth, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                (connection, sql) => connection.Query(sql, mappingFunc),
                async (connection, sql) => await connection.QueryAsync(sql, mappingFunc))
        {
        }
    }

    public abstract class NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TEntity, TId> : NBaseCoreRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        protected NBaseCoreRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                (connection, sql) => connection.Query(sql, mappingFunc),
                async (connection, sql) => await connection.QueryAsync(sql, mappingFunc))
        {
        }
    }

    public abstract class NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity, TId> : NBaseCoreRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        protected NBaseCoreRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                (connection, sql) => connection.Query(sql, mappingFunc),
                async (connection, sql) => await connection.QueryAsync(sql, mappingFunc))
        {
        }
    }

    public abstract class NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity, TId> : NBaseCoreRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        protected NBaseCoreRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                (connection, sql) => connection.Query(sql, mappingFunc),
                async (connection, sql) => await connection.QueryAsync(sql, mappingFunc))
        {
        }
    }
}
