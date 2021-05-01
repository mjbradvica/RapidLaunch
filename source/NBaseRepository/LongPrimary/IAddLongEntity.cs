namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAddLongEntity<in TEntity> : IAddEntity<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
