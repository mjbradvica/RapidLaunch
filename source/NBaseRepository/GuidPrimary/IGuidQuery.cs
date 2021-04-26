namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    public interface IGuidQuery<T> : IQuery<T, Guid>
        where T : IGuidEntity
    {
    }
}
