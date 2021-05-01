namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IDeleteLongEntities<in TEntity> : IDeleteEntities<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
