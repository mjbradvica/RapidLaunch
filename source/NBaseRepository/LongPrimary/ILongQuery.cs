namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// An interface that describe a class that represents a query object for type <see cref="ILongEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ILongQuery<TEntity> : IQuery<TEntity>
        where TEntity : ILongEntity
    {
    }
}
