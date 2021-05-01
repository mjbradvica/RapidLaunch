namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGetByLong<TEntity> : IGetById<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
