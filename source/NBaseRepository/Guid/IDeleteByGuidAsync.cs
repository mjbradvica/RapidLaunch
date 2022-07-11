using NBaseRepository.Common;

namespace NBaseRepository.Guid
{
    /// <summary>
    /// An interface used to describe a class that can delete an entity by <see cref="Guid"/>.
    /// </summary>
    public interface IDeleteByGuidAsync : IDeleteByIdAsync<System.Guid>
    {
    }
}
