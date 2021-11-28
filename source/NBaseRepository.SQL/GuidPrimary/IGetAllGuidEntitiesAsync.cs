namespace NBaseRepository.SQL.GuidPrimary
{
    using System;
    using System.Collections.Generic;
    using Common;
    using NBaseRepository.GuidPrimary;

    public interface IGetAllGuidEntitiesAsync<TEntity> : IGetAllEntitiesAsync<TEntity, Guid, IEnumerable<object>, TEntity>
        where TEntity : IGuidEntity
    {
    }
}
