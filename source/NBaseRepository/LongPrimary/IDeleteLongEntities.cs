namespace NBaseRepository.LongPrimary
{
    using Common;

    public interface IDeleteLongEntities<in TEntity> : IDeleteEntities<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
