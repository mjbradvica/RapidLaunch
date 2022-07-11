namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// An interface used to describe a class that can retrieve all entities of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetAllEntities<out TEntity> : IGetAllEntities<TEntity, long>
        where TEntity : IEntity
    {
    }
}