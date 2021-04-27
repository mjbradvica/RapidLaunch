namespace NBaseRepository.LongPrimary
{
    using Common;

    public interface IGetAllLongEntitiesLazy<TEntity> : IGetAllEntitiesLazy<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
