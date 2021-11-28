using Dapper;
using System.Linq;

namespace NBaseRepository.Dapper
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Common;
    using NBaseRepository.Common;
    using SQL;

    public abstract class BaseRepository<TEntity, TId> :
        IGetAllEntities<TEntity, TId, TEntity, TEntity>
        where TEntity : IEntity<TId>
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
