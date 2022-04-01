namespace NBaseRepository.SQL.GuidPrimary
{
    using System;
    using Common;
    using NBaseRepository.GuidPrimary;

    public interface IGetAllGuidEntities<out TEntity> : IGetAllEntities<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
