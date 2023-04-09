namespace NBaseRepository.EF.Base.IntPrimary
{
    using Common;
    using NBaseRepository.IntPrimary;

    internal interface IGetAllEntitiesLazyAsync<TEntity> : IGetAllEntitiesLazyAsync<TEntity, int>
        where TEntity : IEntity
    {
    }
}
