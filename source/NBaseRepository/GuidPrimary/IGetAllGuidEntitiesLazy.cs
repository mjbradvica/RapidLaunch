namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    public interface IGetAllGuidEntitiesLazy<TEntity> : IGetAllEntitiesLazy<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
