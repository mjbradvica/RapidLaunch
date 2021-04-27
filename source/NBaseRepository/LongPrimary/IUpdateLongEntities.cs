namespace NBaseRepository.LongPrimary
{
    using Common;

    public interface IUpdateLongEntities<in TEntity> : IUpdateEntities<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
