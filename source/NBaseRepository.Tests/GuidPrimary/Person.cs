namespace NBaseRepository.Tests.GuidPrimary
{
    using System;
    using NBaseRepository.GuidPrimary;

    public class Person : IEntity
    {
        public Person()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}
