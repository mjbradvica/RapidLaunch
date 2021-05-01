namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// An interface used to describe a class that has an Id of type <see cref="Guid"/>.
    /// </summary>
    public interface IGuidEntity : IEntity<Guid>
    {
    }
}
