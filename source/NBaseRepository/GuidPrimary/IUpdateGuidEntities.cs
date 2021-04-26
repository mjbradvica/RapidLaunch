namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    public interface IUpdateGuidEntities<in TEntity> : IUpdateEntities<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
