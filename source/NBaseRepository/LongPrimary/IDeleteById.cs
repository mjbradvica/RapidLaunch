namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// An interface used to describe a class that can delete an entity by <see cref="long"/>.
    /// </summary>
    public interface IDeleteById : IDeleteById<long>
    {
    }
}