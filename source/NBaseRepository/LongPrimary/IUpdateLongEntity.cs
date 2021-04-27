namespace NBaseRepository.LongPrimary
{
    using Common;

    public interface IUpdateLongEntity<in TEntity> : IUpdateEntity<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
