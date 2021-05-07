namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// An interface that allows a class to add a single entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAddIntEntity<in TEntity> : IAddEntity<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}