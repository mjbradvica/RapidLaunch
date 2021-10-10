namespace NBaseRepository.ADO
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using SQL;

    public abstract class BaseRepository<T, TId> :
        IGetAllEntities<T, TId>,
        IGetAllEntitiesAsync<T, TId>
        where T : IEntity<TId>
    {
        private readonly SqlBuilder<T, TId> _sqlBuilder;
        private readonly SqlConnection _sqlConnection;
        private readonly Func<IEnumerable<object>, T> _conversionFunc;

        protected BaseRepository(SqlBuilder<T, TId> sqlBuilder, SqlConnection sqlConnection, Func<IEnumerable<object>, T> conversionFunc)
        {
            _sqlBuilder = sqlBuilder;
            _sqlConnection = sqlConnection;
            _conversionFunc = conversionFunc;
        }

        public IReadOnlyList<T> GetAllEntities()
        {
            return ExecuteQuery(_sqlBuilder.SelectAll().Query);
        }

        public IReadOnlyList<T> GetAllEntities(Func<IQueryable<T>, IQueryable<T>> includeFunc)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> GetAllEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(_sqlBuilder.SelectAll().Query, default, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetAllEntitiesAsync(Func<IQueryable<T>, IQueryable<T>> includeFunc, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected int ExecuteNonQuery(string command)
        {
            _sqlConnection.Open();

            var sqlCommand = new SqlCommand(command, _sqlConnection);

            var result = sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();

            return result;
        }

        protected async Task<int> ExecuteNonQueryAsync(string command, CancellationToken cancellationToken = default)
        {
            await _sqlConnection.OpenAsync(cancellationToken);

            var sqlCommand = new SqlCommand(command, _sqlConnection);

            var result = await sqlCommand.ExecuteNonQueryAsync(cancellationToken);

            await _sqlConnection.CloseAsync();

            return result;
        }

        protected List<T> ExecuteQuery(string command, Func<IEnumerable<object>, T> overloadDefaultConversion = default)
        {
            var sqlQuery = new SqlCommand(command, _sqlConnection);

            _sqlConnection.Open();

            var sqlDataReader = sqlQuery.ExecuteReader();

            var result = new List<T>();

            var conversionFunc = overloadDefaultConversion ?? _conversionFunc;

            while (sqlDataReader.Read())
            {
                var rowObjects = new List<object>();

                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    rowObjects.Add(sqlDataReader[i]);
                }

                result.Add(conversionFunc.Invoke(rowObjects));
            }

            _sqlConnection.Close();

            return result;
        }

        protected async Task<List<T>> ExecuteQueryAsync(string command, Func<IEnumerable<object>, T> overloadDefaultConversion = default, CancellationToken cancellationToken = default)
        {
            var sqlQuery = new SqlCommand(command, _sqlConnection);

            await _sqlConnection.OpenAsync(cancellationToken);

            var sqlDataReader = await sqlQuery.ExecuteReaderAsync(cancellationToken);

            var result = new List<T>();

            var conversionFunc = overloadDefaultConversion ?? _conversionFunc;

            while (await sqlDataReader.ReadAsync(cancellationToken))
            {
                var rowObjects = new List<object>();

                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    rowObjects.Add(sqlDataReader[i]);
                }

                result.Add(conversionFunc.Invoke(rowObjects));
            }

            await _sqlConnection.CloseAsync();

            return result;
        }
    }
}
