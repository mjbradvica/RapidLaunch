namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IAddLongEntity<in TEntity> : IAddEntity<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
