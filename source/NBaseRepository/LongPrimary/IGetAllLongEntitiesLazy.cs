namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGetAllLongEntitiesLazy<TEntity> : IGetAllEntitiesLazy<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
