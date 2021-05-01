namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGetByGuid<TEntity> : IGetById<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
