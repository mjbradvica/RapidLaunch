namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IUpdateLongEntities<in TEntity> : IUpdateEntities<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
