namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ISearchLongEntities<TEntity> : ISearchEntities<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
