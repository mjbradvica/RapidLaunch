namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    public interface ISearchGuidEntitiesLazy<TEntity> : ISearchEntitiesLazy<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
