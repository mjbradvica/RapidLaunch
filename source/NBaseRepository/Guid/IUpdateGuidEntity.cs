using NBaseRepository.Common;

namespace NBaseRepository.Guid
{
    /// <summary>
    /// An interface used to describe a class that can update an entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IUpdateGuidEntity<in TEntity> : IUpdateEntity<TEntity, System.Guid>
        where TEntity : IEntity
    {
    }
}