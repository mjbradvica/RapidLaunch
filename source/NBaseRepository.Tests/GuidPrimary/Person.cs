using NBaseRepository.Guid;

namespace NBaseRepository.Tests.GuidPrimary
{
    using System;

    public class Person : IEntity
    {
        public Person()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}
