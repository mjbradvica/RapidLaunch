namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// An interface that allows a class to add a single entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAddLongEntity<in TEntity> : IAddEntity<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}