namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ISearchLongEntitiesLazy<TEntity> : ISearchEntitiesLazy<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
