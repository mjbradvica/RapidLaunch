using NBaseRepository.Common;

namespace NBaseRepository.Long
{
    /// <summary>
    /// An interface that allows a class to add a single entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAddLongEntityAsync<in TEntity> : IAddEntityAsync<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
