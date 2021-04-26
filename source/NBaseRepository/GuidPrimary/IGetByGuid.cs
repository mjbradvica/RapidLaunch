namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    public interface IGetByGuid<TEntity> : IGetById<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
