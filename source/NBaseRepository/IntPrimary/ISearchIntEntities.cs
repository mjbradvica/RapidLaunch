namespace NBaseRepository.IntPrimary
{
    using Common;

    public interface ISearchIntEntities<TEntity> : ISearchEntities<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
