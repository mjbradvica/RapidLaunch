using NBaseRepository.Common;

namespace NBaseRepository.Int
{
    /// <summary>
    /// An interface used to describe a class that can update an entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IUpdateIntEntityAsync<in TEntity> : IUpdateEntityAsync<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
