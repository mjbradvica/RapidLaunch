namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// An interface used to describe a class that can update an entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IUpdateIntEntity<in TEntity> : IUpdateEntity<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}