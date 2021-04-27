namespace NBaseRepository.IntPrimary
{
    using Common;

    public interface ISearchIntEntitiesLazy<TEntity> : ISearchEntitiesLazy<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
