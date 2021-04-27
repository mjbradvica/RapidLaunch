namespace NBaseRepository.LongPrimary
{
    using Common;

    public interface IDeleteLongEntity<in TEntity> : IDeleteEntity<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
