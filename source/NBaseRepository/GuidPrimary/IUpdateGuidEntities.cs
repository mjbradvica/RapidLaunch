namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IUpdateGuidEntities<in TEntity> : IUpdateEntities<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
