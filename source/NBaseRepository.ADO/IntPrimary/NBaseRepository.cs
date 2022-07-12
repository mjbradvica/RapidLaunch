namespace NBaseRepository.ADO.IntPrimary
{
    using System;
    using System.Data.SqlClient;
    using Common;
    using NBaseRepository.Common;
    using NBaseRepository.IntPrimary;

    public abstract class NBaseRepository<TEntity> : NBaseCoreRepository<TEntity, int>
        where TEntity : IEntity
    {
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlConnection, sqlBuilder, conversionFunc)
        {
        }
    }
}
