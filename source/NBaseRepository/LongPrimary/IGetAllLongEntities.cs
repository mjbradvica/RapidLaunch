namespace NBaseRepository.LongPrimary
{
    using Common;

    public interface IGetAllLongEntities<TEntity> : IGetAllEntities<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
