using NBaseRepository.Common;

namespace NBaseRepository.Long
{
    /// <summary>
    /// An interface used to describe a class that can delete an entity by <see cref="long"/>.
    /// </summary>
    public interface IDeleteByLong : IDeleteById<long>
    {
    }
}