namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IAddLongEntities<in TEntity> : IAddEntities<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
