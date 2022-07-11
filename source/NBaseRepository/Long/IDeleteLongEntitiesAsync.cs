using NBaseRepository.Common;

namespace NBaseRepository.Long
{
    /// <summary>
    /// An interface used to describe a class that can delete multiple entities of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IDeleteLongEntitiesAsync<in TEntity> : IDeleteEntitiesAsync<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
