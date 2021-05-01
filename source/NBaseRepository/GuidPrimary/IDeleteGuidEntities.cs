namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IDeleteGuidEntities<in TEntity> : IDeleteEntities<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
