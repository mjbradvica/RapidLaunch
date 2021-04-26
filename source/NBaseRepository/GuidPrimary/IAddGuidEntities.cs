namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    public interface IAddGuidEntities<in TEntity> : IAddEntities<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
