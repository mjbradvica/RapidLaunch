namespace NBaseRepository.EF.Base.IntPrimary
{
    using Common;
    using NBaseRepository.IntPrimary;

    internal interface ISearchEntitiesLazyAsync<TEntity> : ISearchEntitiesLazyAsync<TEntity, int>
        where TEntity : IEntity
    {
    }
}
