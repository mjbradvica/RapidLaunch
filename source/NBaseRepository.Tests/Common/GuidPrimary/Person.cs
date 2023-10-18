// <copyright file="Person.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using NBaseRepository.GuidPrimary;

namespace NBaseRepository.Tests.Common.GuidPrimary
{
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

        /// <inheritdoc/>
        public Guid Id { get; }

        public IEnumerable<Pet> Pets { get; }
    }
}
