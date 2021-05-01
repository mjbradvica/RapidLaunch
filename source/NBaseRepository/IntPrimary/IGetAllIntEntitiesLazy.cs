namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGetAllIntEntitiesLazy<TEntity> : IGetAllEntitiesLazy<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
