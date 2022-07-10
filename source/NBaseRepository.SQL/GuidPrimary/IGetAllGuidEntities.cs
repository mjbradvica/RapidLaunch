namespace NBaseRepository.SQL.GuidPrimary
{
    using System;
    using NBaseRepository.Common;
    using NBaseRepository.GuidPrimary;

    public interface IGetAllGuidEntities<out TEntity> : IGetAllEntities<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
