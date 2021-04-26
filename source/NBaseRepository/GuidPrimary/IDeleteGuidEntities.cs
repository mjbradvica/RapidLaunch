namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    public interface IDeleteGuidEntities<in TEntity> : IDeleteEntities<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
