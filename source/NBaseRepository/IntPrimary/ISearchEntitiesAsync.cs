namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins for type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ISearchEntitiesAsync<TEntity> : ISearchEntitiesAsync<TEntity, int>
        where TEntity : IEntity
    {
    }
}
