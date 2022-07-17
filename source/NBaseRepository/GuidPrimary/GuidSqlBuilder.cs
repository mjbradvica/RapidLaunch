namespace NBaseRepository.GuidPrimary
{
    using System;
    using NBaseRepository.Common;

    public abstract class GuidSqlBuilder<TEntity> : SqlBuilder<TEntity, Guid>
        where TEntity : IEntity
    {
        protected GuidSqlBuilder()
        {
        }

        protected GuidSqlBuilder(string tableName)
            : base(tableName)
        {
        }
    }
}
