namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ISearchLongEntities<TEntity> : ISearchEntities<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
