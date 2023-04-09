namespace NBaseRepository.EF.Base.LongPrimary
{
    using Common;
    using NBaseRepository.LongPrimary;

    internal interface ISearchEntitiesLazyAsync<TEntity> : ISearchEntitiesLazyAsync<TEntity, long>
        where TEntity : IEntity
    {
    }
}
