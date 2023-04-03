namespace NBaseRepository.EF.Base.GuidPrimary
{
    using System;
    using Common;
    using NBaseRepository.GuidPrimary;

    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins for type <see cref="TEntity"/> lazily.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ISearchEntitiesLazy<TEntity> : ISearchEntitiesLazy<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}
