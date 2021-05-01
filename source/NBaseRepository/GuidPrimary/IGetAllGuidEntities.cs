namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetAllGuidEntities<TEntity> : IGetAllEntities<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
