namespace NBaseRepository.LongPrimary
{
    using Common;

    public interface IAddLongEntities<in TEntity> : IAddEntities<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
