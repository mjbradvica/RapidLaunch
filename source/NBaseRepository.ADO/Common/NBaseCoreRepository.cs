namespace NBaseRepository.ADO.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading;
    using System.Threading.Tasks;
    using NBaseRepository.Common;

    public abstract class NBaseCoreRepository<TEntity, TId> :
        IGetAllEntities<TEntity, TId>,
        IGetAllEntitiesAsync<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        private readonly SqlConnection _sqlConnection;
        private readonly SqlBuilder<TEntity, TId> _sqlBuilder;
        private readonly Func<SqlDataReader, TEntity> _conversionFunc;

        protected NBaseCoreRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, TId> sqlBuilder, Func<SqlDataReader, TEntity> conversionFunc)
        {
            _sqlConnection = sqlConnection;
            _sqlBuilder = sqlBuilder;
            _conversionFunc = conversionFunc;
        }

        public virtual IReadOnlyList<TEntity> GetAllEntities()
        {
            return ExecuteQuery(_sqlBuilder.SelectAll().Query);
        }

        public virtual IReadOnlyList<TEntity> GetAllEntities(Func<SqlDataReader, TEntity> conversionFunc)
        {
            return ExecuteQuery(_sqlBuilder.SelectAll().Query, conversionFunc);
        }

        public virtual async Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(_sqlBuilder.SelectAll().Query, default, cancellationToken);
        }

        protected int ExecuteNonQuery(string command)
        {
            _sqlConnection.Open();

            var transaction = _sqlConnection.BeginTransaction();

            var sqlCommand = new SqlCommand(command, _sqlConnection);

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
                _sqlConnection.Close();
            }

            return result;
        }

        protected async Task<int> ExecuteNonQueryAsync(string command, CancellationToken cancellationToken = default)
        {
            await _sqlConnection.OpenAsync(cancellationToken);

            var transaction = await _sqlConnection.BeginTransactionAsync(cancellationToken);

            var sqlCommand = new SqlCommand(command, _sqlConnection);

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
                await _sqlConnection.CloseAsync();
            }

            return result;
        }

        protected List<TEntity> ExecuteQuery(string command, Func<SqlDataReader, TEntity> overloadDefaultConversion = default)
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

        protected async Task<List<TEntity>> ExecuteQueryAsync(string command, Func<SqlDataReader, TEntity> overloadDefaultConversion = default, CancellationToken cancellationToken = default)
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
    }
}
