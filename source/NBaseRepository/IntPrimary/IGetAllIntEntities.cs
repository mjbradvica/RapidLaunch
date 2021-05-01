namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// An interface used to describe a class that can retrieve all entities of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetAllIntEntities<TEntity> : IGetAllEntities<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
