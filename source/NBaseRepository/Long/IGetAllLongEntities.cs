using NBaseRepository.Common;

namespace NBaseRepository.Long
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all entities of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetAllLongEntities<TEntity> : IGetAllEntities<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}