namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ISearchIntEntities<TEntity> : ISearchEntities<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
