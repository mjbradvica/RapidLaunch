namespace NBaseRepository.Common
{
    /// <summary>
    /// An interface used to describe a class that has an Id.
    /// </summary>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IEntity<out TId>
    {
        /// <summary>
        /// Gets the Id of the entity.
        /// </summary>
        TId Id { get; }
    }
}
