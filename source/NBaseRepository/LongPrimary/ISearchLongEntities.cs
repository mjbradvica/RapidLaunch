namespace NBaseRepository.LongPrimary
{
    using Common;

    public interface ISearchLongEntities<TEntity> : ISearchEntities<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
