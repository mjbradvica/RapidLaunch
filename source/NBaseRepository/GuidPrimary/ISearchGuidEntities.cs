namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    public interface ISearchGuidEntities<TEntity> : ISearchEntities<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
