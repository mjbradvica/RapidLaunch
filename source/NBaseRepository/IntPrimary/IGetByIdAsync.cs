namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// An interface used to describe a class that can retrieve a single entity of type <see cref="TEntity"/> by Id of type <see cref="int"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetByIdAsync<TEntity> : IGetByIdAsync<TEntity, int>
        where TEntity : IEntity
    {
    }
}
