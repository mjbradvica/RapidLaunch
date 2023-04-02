namespace NBaseRepository.Tests.Common.GuidPrimary
{
    using System;
    using System.Collections.Generic;
    using NBaseRepository.GuidPrimary;

    internal class Person : IEntity
    {
        public Person()
        {
            Id = Guid.NewGuid();
            Pets = new List<Pet>();
        }

        public Person(Guid id, IEnumerable<Pet> pets)
        {
            Id = id;
            Pets = pets;
        }

        public Guid Id { get; }

        public IEnumerable<Pet> Pets { get; }
    }
}
