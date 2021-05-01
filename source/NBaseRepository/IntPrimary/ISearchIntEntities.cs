namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ISearchIntEntities<TEntity> : ISearchEntities<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
