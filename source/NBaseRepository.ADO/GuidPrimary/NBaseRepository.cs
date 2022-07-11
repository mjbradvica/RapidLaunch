namespace NBaseRepository.ADO.GuidPrimary
{
    using System;
    using System.Data.SqlClient;
    using Common;
    using NBaseRepository.Common;
    using NBaseRepository.GuidPrimary;

    public abstract class NBaseRepository<TEntity> : NBaseRepository<TEntity, Guid>
        where TEntity : IEntity
    {
        protected NBaseRepository(SqlBuilder<TEntity, Guid> sqlBuilder, SqlConnection sqlConnection, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlBuilder, sqlConnection, conversionFunc)
        {
        }
    }
}
