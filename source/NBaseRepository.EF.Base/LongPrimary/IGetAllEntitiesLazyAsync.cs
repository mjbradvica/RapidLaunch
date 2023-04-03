namespace NBaseRepository.EF.Base.LongPrimary
{
    using Common;
    using NBaseRepository.LongPrimary;

    internal interface IGetAllEntitiesLazyAsync<TEntity> : IGetAllEntitiesLazyAsync<TEntity, long>
        where TEntity : IEntity
    {
    }
}
