namespace NBaseRepository.IntPrimary
{
    using Common;

    public abstract class IntSqlBuilder<TEntity> : SqlBuilder<TEntity, int>
        where TEntity : IEntity
    {
        protected IntSqlBuilder()
        {
        }

        protected IntSqlBuilder(string tableName)
            : base(tableName)
        {
        }
    }
}
