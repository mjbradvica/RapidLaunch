namespace NBaseRepository.ADO
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using SQL;

    public abstract class BaseAdoRepository<TEntity, TId> :
        IGetAllEntities<TEntity, TId>,
        IGetAllEntitiesAsync<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        protected BaseAdoRepository(SqlBuilder<TEntity, TId> sqlBuilder, SqlConnection sqlConnection, Func<SqlDataReader, TEntity> conversionFunc)
        {
            SqlBuilder = sqlBuilder;
            SqlConnection = sqlConnection;
            ConversionFunc = conversionFunc;
        }

        protected SqlBuilder<TEntity, TId> SqlBuilder { get; }

        protected SqlConnection SqlConnection { get; }

        protected Func<SqlDataReader, TEntity> ConversionFunc { get; }

        public virtual IReadOnlyList<TEntity> GetAllEntities()
        {
            return ExecuteQuery(SqlBuilder.SelectAll().Query);
        }

        public virtual async Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(SqlBuilder.SelectAll().Query, default, cancellationToken);
        }

        protected int ExecuteNonQuery(string command)
        {
            SqlConnection.Open();

            var transaction = SqlConnection.BeginTransaction();

            var sqlCommand = new SqlCommand(command, SqlConnection);

            int result;

            try
            {
                result = sqlCommand.ExecuteNonQuery();

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

        protected async Task<int> ExecuteNonQueryAsync(string command, CancellationToken cancellationToken = default)
        {
            await SqlConnection.OpenAsync(cancellationToken);

            var transaction = await SqlConnection.BeginTransactionAsync(cancellationToken);

            var sqlCommand = new SqlCommand(command, SqlConnection);

            int result;

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
                await SqlConnection.CloseAsync();
            }

            return result;
        }

        protected List<TEntity> ExecuteQuery(string command, Func<SqlDataReader, TEntity> overloadDefaultConversion = default)
        {
            SqlConnection.Open();

            var sqlQuery = new SqlCommand(command, SqlConnection);

            var result = new List<TEntity>();

            try
            {
                var sqlDataReader = sqlQuery.ExecuteReader();

                var conversionFunc = overloadDefaultConversion ?? ConversionFunc;

                while (sqlDataReader.Read())
                {
                    result.Add(conversionFunc.Invoke(sqlDataReader));
                }
            }
            finally
            {
                SqlConnection.Close();
            }

            return result;
        }

        protected async Task<List<TEntity>> ExecuteQueryAsync(string command, Func<SqlDataReader, TEntity> overloadDefaultConversion = default, CancellationToken cancellationToken = default)
        {
            await SqlConnection.OpenAsync(cancellationToken);

            var sqlQuery = new SqlCommand(command, SqlConnection);

            var result = new List<TEntity>();

            try
            {
                var sqlDataReader = await sqlQuery.ExecuteReaderAsync(cancellationToken);

                var conversionFunc = overloadDefaultConversion ?? ConversionFunc;

                while (await sqlDataReader.ReadAsync(cancellationToken))
                {
                    result.Add(conversionFunc.Invoke(sqlDataReader));
                }
            }
            finally
            {
                await SqlConnection.CloseAsync();
            }

            return result;
        }
    }
}
