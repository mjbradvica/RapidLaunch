namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    public interface IDeleteGuidEntity<in TEntity> : IDeleteEntity<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
