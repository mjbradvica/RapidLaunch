using NBaseRepository.Common;

namespace NBaseRepository.Int
{
    /// <summary>
    /// An interface that describe a class that represents a query object for type <see cref="IIntEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IIntQuery<TEntity> : IQuery<TEntity>
        where TEntity : IIntEntity
    {
    }
}
