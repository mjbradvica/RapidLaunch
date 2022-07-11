namespace NBaseRepository.ADO
{
    using System;
    using System.Data.SqlClient;

    public abstract class BaseGuidRepository<TEntity> : BaseRepository<TEntity, Guid>
        where TEntity : IEntity
    {
        protected BaseGuidRepository(SqlBuilder<TEntity, Guid> sqlBuilder, SqlConnection sqlConnection, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlBuilder, sqlConnection, conversionFunc)
        {
        }
    }
}
