namespace NBaseRepository.ADO
{
    using System;
    using System.Data.SqlClient;
    using GuidPrimary;
    using SQL;

    public abstract class BaseAdoGuidRepository<TEntity> : BaseAdoRepository<TEntity, Guid>
        where TEntity : IGuidEntity
    {
        protected BaseAdoGuidRepository(SqlBuilder<TEntity, Guid> sqlBuilder, SqlConnection sqlConnection, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlBuilder, sqlConnection, conversionFunc)
        {
        }
    }
}
