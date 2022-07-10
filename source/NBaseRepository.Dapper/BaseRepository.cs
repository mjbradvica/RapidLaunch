using Dapper;

namespace NBaseRepository.Dapper
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using Common;
    using SQL;

    public abstract class BaseRepository<TEntity, TId> :
        IGetAllEntities<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        private readonly SqlConnection _sqlConnection;

        protected BaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, TId> databaseBuilder)
        {
            _sqlConnection = sqlConnection;
            DatabaseBuilder = databaseBuilder;
        }

        protected SqlBuilder<TEntity, TId> DatabaseBuilder { get; }

        public IReadOnlyList<TEntity> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<TEntity> GetAllEntities(Func<TEntity, TEntity> includeFunc)
        {
            return _sqlConnection.Query<TEntity>(DatabaseBuilder.SelectAll().Query).ToList();
        }
    }
}
