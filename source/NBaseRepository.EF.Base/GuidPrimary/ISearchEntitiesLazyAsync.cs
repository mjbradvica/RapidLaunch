namespace NBaseRepository.EF.Base.GuidPrimary
{
    using System;
    using Common;
    using NBaseRepository.GuidPrimary;

    internal interface ISearchEntitiesLazyAsync<TEntity> : ISearchEntitiesLazyAsync<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}
