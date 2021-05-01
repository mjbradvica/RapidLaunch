namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IUpdateLongEntity<in TEntity> : IUpdateEntity<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
