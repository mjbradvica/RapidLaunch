namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IDeleteGuidEntity<in TEntity> : IDeleteEntity<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
