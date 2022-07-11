using NBaseRepository.Common;

namespace NBaseRepository.Long
{
    /// <summary>
    /// An interface used to describe a class that can delete an entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IDeleteLongEntity<in TEntity> : IDeleteEntity<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}