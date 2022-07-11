using NBaseRepository.Common;

namespace NBaseRepository.Guid
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all entities of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetAllGuidEntitiesAsync<TEntity> : IGetAllEntitiesAsync<TEntity, System.Guid>
        where TEntity : IEntity
    {
    }
}
