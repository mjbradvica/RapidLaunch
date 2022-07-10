namespace NBaseRepository.ADO
{
    using System;
    using System.Data.SqlClient;
    using GuidPrimary;
    using SQL;

    public abstract class BaseGuidRepository<TEntity> : BaseRepository<TEntity, Guid>
        where TEntity : IGuidEntity
    {
        protected BaseGuidRepository(SqlBuilder<TEntity, Guid> sqlBuilder, SqlConnection sqlConnection, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlBuilder, sqlConnection, conversionFunc)
        {
        }
    }
}
