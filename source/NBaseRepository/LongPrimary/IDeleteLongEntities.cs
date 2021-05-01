namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IDeleteLongEntities<in TEntity> : IDeleteEntities<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
