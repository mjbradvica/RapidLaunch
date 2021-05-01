namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ISearchIntEntitiesLazy<TEntity> : ISearchEntitiesLazy<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
