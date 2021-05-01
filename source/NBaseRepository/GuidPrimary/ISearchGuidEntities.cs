namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ISearchGuidEntities<TEntity> : ISearchEntities<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
