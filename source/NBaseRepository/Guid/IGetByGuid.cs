using NBaseRepository.Common;

namespace NBaseRepository.Guid
{
    /// <summary>
    /// An interface used to describe a class that can retrieve a single entity of type <see cref="TEntity"/> by Id of type <see cref="Guid"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetByGuid<out TEntity> : IGetById<TEntity, System.Guid>
        where TEntity : IEntity
    {
    }
}