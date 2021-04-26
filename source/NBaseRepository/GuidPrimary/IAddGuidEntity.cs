namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    public interface IAddGuidEntity<in TEntity> : IAddEntity<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
