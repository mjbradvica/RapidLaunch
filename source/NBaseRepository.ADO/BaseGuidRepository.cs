namespace NBaseRepository.ADO
{
    using System;
    using System.Data.SqlClient;
    using Common;

    public abstract class BaseGuidRepository<TEntity> : BaseRepository<TEntity, Guid>
        where TEntity : IEntity<Guid>
    {
        protected BaseGuidRepository(SqlBuilder<TEntity, Guid> sqlBuilder, SqlConnection sqlConnection, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlBuilder, sqlConnection, conversionFunc)
        {
        }
    }
}
