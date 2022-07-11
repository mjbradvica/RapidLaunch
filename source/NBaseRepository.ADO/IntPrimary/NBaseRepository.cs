namespace NBaseRepository.ADO.IntPrimary
{
    using System;
    using System.Data.SqlClient;
    using NBaseRepository.ADO.Common;
    using NBaseRepository.Common;
    using NBaseRepository.IntPrimary;

    public abstract class NBaseRepository<TEntity> : NBaseRepository<TEntity, int>
        where TEntity : IEntity
    {
        protected NBaseRepository(SqlBuilder<TEntity, int> sqlBuilder, SqlConnection sqlConnection, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlBuilder, sqlConnection, conversionFunc)
        {
        }
    }
}
