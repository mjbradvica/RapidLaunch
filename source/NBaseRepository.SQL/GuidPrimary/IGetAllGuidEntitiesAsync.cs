namespace NBaseRepository.SQL.GuidPrimary
{
    using System;
    using Common;
    using NBaseRepository.GuidPrimary;

    public interface IGetAllGuidEntitiesAsync<TEntity> : IGetAllEntitiesAsync<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
