namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGetAllGuidEntitiesLazy<TEntity> : IGetAllEntitiesLazy<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
