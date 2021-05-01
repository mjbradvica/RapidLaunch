namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IUpdateLongEntity<in TEntity> : IUpdateEntity<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
