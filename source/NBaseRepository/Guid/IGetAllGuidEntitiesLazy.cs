using NBaseRepository.Common;

namespace NBaseRepository.Guid
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all entity of type <see cref="TEntity"/> lazily.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetAllGuidEntitiesLazy<TEntity> : IGetAllEntitiesLazy<TEntity, System.Guid>
        where TEntity : IEntity
    {
    }
}
