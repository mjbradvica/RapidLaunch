namespace NBaseRepository.SQL.GuidPrimary
{
    using System;
    using Common;

    public interface ISearchGuidEntitiesAsync<TEntity> : ISearchEntitiesAsync<TEntity, Guid>
        where TEntity : IEntity<Guid>
    {
    }
}
