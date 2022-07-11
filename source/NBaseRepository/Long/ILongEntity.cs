using NBaseRepository.Common;

namespace NBaseRepository.Long
{
    /// <summary>
    /// An interface used to describe a class that has an Id of type <see cref="long"/>.
    /// </summary>
    public interface ILongEntity : IEntity<long>
    {
    }

    public interface IEntity : IEntity<long>
    {
    }
}
