namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IDeleteLongEntity<in TEntity> : IDeleteEntity<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
