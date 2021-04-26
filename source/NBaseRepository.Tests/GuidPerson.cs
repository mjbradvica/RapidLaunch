namespace NBaseRepository.Tests
{
    using System;

    public class GuidPerson : IGuidEntity
    {
        public GuidPerson()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}
