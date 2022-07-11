using NBaseRepository.Common;

namespace NBaseRepository.Guid
{
    /// <summary>
    /// An interface used to describe a class that can add multiple entities of type <see cref="TEntity"/> at one time.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAddGuidEntitiesAsync<in TEntity> : IAddEntitiesAsync<TEntity, System.Guid>
        where TEntity : IEntity
    {
    }
}
