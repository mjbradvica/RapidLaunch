namespace NBaseRepository.ADO.LongPrimary
{
    using System;
    using System.Data.SqlClient;
    using NBaseRepository.ADO.Common;
    using NBaseRepository.Common;
    using NBaseRepository.LongPrimary;

    public abstract class NBaseRepository<TEntity> : NBaseRepository<TEntity, long>
        where TEntity : IEntity
    {
        protected NBaseRepository(SqlBuilder<TEntity, long> sqlBuilder, SqlConnection sqlConnection, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlBuilder, sqlConnection, conversionFunc)
        {
        }
    }
}
