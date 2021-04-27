namespace NBaseRepository.LongPrimary
{
    using Common;

    public interface ISearchLongEntitiesLazy<TEntity> : ISearchEntitiesLazy<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
