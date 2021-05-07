namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// An interface used to describe a class that can add multiple entities of type <see cref="TEntity"/> at one time.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAddLongEntitiesAsync<in TEntity> : IAddEntitiesAsync<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
