namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    public interface IGetByIdAsync<TEntity> : IGetByIdAsync<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}
