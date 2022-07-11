using NBaseRepository.Common;

namespace NBaseRepository.Guid
{
    /// <summary>
    /// An interface used to describe a class that has an Id of type <see cref="Guid"/>.
    /// </summary>
    public interface IEntity : IEntity<System.Guid>
    {
    }
}
