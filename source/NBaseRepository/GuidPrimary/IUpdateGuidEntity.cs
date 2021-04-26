namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    public interface IUpdateGuidEntity<in TEntity> : IUpdateEntity<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
