namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGetAllLongEntities<TEntity> : IGetAllEntities<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
