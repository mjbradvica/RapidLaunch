namespace NBaseRepository.LongPrimary
{
    using Common;

    public interface IAddLongEntity<in TEntity> : IAddEntity<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
