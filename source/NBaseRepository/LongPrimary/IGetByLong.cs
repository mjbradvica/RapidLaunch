namespace NBaseRepository.LongPrimary
{
    using Common;

    public interface IGetByLong<TEntity> : IGetById<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
