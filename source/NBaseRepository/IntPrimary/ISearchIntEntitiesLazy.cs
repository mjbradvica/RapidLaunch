namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ISearchIntEntitiesLazy<TEntity> : ISearchEntitiesLazy<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
