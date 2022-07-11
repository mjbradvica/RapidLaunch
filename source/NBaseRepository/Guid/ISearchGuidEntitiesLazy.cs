using NBaseRepository.Common;

namespace NBaseRepository.Guid
{
    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins for type <see cref="TEntity"/> lazily.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ISearchGuidEntitiesLazy<TEntity> : ISearchEntitiesLazy<TEntity, System.Guid>
        where TEntity : IEntity
    {
    }
}
