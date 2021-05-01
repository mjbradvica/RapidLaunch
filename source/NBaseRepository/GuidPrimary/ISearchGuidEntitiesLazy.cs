namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ISearchGuidEntitiesLazy<TEntity> : ISearchEntitiesLazy<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
