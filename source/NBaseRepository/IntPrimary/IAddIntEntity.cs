namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// An interface that allows a class to add a single entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAddIntEntity<in T> : IAddEntity<T, int>
        where T : IIntEntity
    {
    }
}