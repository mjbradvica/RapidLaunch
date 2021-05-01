namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IAddGuidEntity<in TEntity> : IAddEntity<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
