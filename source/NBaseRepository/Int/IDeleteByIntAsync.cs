using NBaseRepository.Common;

namespace NBaseRepository.Int
{
    /// <summary>
    /// An interface used to describe a class that can delete an entity by <see cref="int"/>.
    /// </summary>
    public interface IDeleteByIntAsync : IDeleteByIdAsync<int>
    {
    }
}
