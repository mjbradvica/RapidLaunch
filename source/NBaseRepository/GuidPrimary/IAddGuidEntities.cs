namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IAddGuidEntities<in TEntity> : IAddEntities<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
