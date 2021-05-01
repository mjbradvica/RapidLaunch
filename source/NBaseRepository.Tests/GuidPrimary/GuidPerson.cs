namespace NBaseRepository.Tests.GuidPrimary
{
    using System;
    using NBaseRepository.GuidPrimary;

    public class GuidPerson : IGuidEntity
    {
        public GuidPerson()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}
