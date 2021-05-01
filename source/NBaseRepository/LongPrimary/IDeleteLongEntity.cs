namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IDeleteLongEntity<in TEntity> : IDeleteEntity<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
