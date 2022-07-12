namespace NBaseRepository.ADO.GuidPrimary
{
    using System;
    using System.Data.SqlClient;
    using Common;
    using NBaseRepository.Common;
    using NBaseRepository.GuidPrimary;

    public abstract class NBaseRepository<TEntity> : NBaseCoreRepository<TEntity, Guid>
        where TEntity : IEntity
    {
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, Guid> sqlBuilder, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlConnection, sqlBuilder, conversionFunc)
        {
        }
    }
}
