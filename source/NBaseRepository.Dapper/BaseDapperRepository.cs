using Dapper;

namespace NBaseRepository.Dapper
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using SQL;

    public abstract class BaseDapperRepository<TEntity, TId> :
        IGetAllEntities<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        private readonly Func<SqlConnection, string, IEnumerable<TEntity>> _executionFunc;
        private readonly Func<SqlConnection, string, Task<IEnumerable<TEntity>>> _asyncExecutionFunc;

        protected BaseDapperRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<SqlConnection, string, IEnumerable<TEntity>> executionFunc,
            Func<SqlConnection, string, Task<IEnumerable<TEntity>>> asyncExecutionFunc)
        {
            SqlConnection = sqlConnection;
            SqlBuilder = sqlBuilder;
            _executionFunc = executionFunc;
            _asyncExecutionFunc = asyncExecutionFunc;
        }

        protected SqlConnection SqlConnection { get; }

        protected SqlBuilder<TEntity, TId> SqlBuilder { get; }

        public IReadOnlyList<TEntity> GetAllEntities()
        {
            var result = ExecuteQuery(SqlBuilder.SelectAll().Query);

            return result.ToList();
        }

        private IEnumerable<TEntity> ExecuteQuery(string sql)
        {
            return _executionFunc.Invoke(SqlConnection, sql);
        }

        private async Task<IEnumerable<TEntity>> ExecuteQueryAsync(string sql)
        {
            return await _asyncExecutionFunc.Invoke(SqlConnection, sql);
        }

        private int ExecuteNonQuery(string sql)
        {
            SqlConnection.Open();

            var transaction = SqlConnection.BeginTransaction();

            int result;

            try
            {
                result = SqlConnection.Execute(sql, null, transaction);

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();

                throw;
            }
            finally
            {
                SqlConnection.Close();
            }

            return result;
        }

        private async Task<int> ExecuteNonQueryAsync(string sql)
        {
            await SqlConnection.OpenAsync();

            var transaction = await SqlConnection.BeginTransactionAsync();

            int result;

            try
            {
                result = await SqlConnection.ExecuteAsync(sql, null, transaction);

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();

                throw;
            }
            finally
            {
                await SqlConnection.CloseAsync();
            }

            return result;
        }
    }

    public abstract class BaseDapperRepository<TFirst, TEntity, TId> : BaseDapperRepository<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        protected BaseDapperRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, TId> sqlBuilder, Func<TFirst, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                (connection, sql) => connection.Query<TFirst>(sql).Select(mappingFunc.Invoke).ToList(),
                async (connection, sql) =>
                {
                    var result = await connection.QueryAsync<TFirst>(sql);

                    return result.Select(mappingFunc.Invoke).ToList();
                })
        {
        }
    }

    public abstract class BaseDapperRepository<TFirst, TSecond, TEntity, TId> : BaseDapperRepository<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        protected BaseDapperRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, TId> sqlBuilder, Func<TFirst, TSecond, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                (connection, sql) => connection.Query(sql, mappingFunc),
                async (connection, sql) => await connection.QueryAsync(sql, mappingFunc))
        {
        }
    }
}
