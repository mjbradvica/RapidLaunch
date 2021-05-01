namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IUpdateGuidEntity<in TEntity> : IUpdateEntity<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
