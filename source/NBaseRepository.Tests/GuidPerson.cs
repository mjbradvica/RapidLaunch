namespace NBaseRepository.Tests
{
    using System;
    using GuidPrimary;

    public class GuidPerson : IGuidEntity
    {
        public GuidPerson()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}
