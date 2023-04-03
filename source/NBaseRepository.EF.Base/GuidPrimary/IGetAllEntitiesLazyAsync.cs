namespace NBaseRepository.EF.Base.GuidPrimary
{
    using System;
    using Common;
    using NBaseRepository.GuidPrimary;

    public interface IGetAllEntitiesLazyAsync<TEntity> : IGetAllEntitiesLazyAsync<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}
