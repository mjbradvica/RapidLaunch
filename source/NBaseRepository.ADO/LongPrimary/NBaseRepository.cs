namespace NBaseRepository.ADO.LongPrimary
{
    using System;
    using System.Data.SqlClient;
    using Common;
    using NBaseRepository.Common;
    using NBaseRepository.LongPrimary;

    public abstract class NBaseRepository<TEntity> : NBaseCoreRepository<TEntity, long>
        where TEntity : IEntity
    {
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, long> sqlBuilder, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlConnection, sqlBuilder, conversionFunc)
        {
        }
    }
}
