using NBaseRepository.Common;

namespace NBaseRepository.Guid
{
    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins for type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ISearchGuidEntitiesAsync<TEntity> : ISearchEntitiesAsync<TEntity, System.Guid>
        where TEntity : IEntity
    {
    }
}
