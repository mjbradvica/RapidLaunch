namespace NBaseRepository.LongPrimary
{
    using Common;

    public abstract class LongSqlBuilder<TEntity> : SqlBuilder<TEntity, long>
        where TEntity : IEntity
    {
        protected LongSqlBuilder()
        {
        }

        protected LongSqlBuilder(string tableName)
        : base(tableName)
        {
        }
    }
}
