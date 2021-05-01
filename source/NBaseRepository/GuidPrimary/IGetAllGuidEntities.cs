namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGetAllGuidEntities<TEntity> : IGetAllEntities<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
