namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    public interface IGetAllGuidEntities<TEntity> : IGetAllEntities<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
