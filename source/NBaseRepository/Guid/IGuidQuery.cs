using NBaseRepository.Common;

namespace NBaseRepository.Guid
{
    /// <summary>
    /// An interface that describe a class that represents a query object for type <see cref="IEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGuidQuery<TEntity> : IQuery<TEntity>
        where TEntity : IEntity
    {
    }
}
