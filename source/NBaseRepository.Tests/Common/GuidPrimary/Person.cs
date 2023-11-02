// <copyright file="Person.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using NBaseRepository.GuidPrimary;

namespace NBaseRepository.Tests.Common.GuidPrimary
{
    /// <summary>
    /// Test entity.
    /// </summary>
    internal class Person : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
            Id = Guid.NewGuid();
            Pets = new List<Pet>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="id">The person identifier.</param>
        /// <param name="pets">The pets for a person.</param>
        public Person(Guid id, IEnumerable<Pet> pets)
        {
            Id = id;
            Pets = pets;
        }

        /// <inheritdoc/>
        public Guid Id { get; }

        /// <summary>
        /// Gets a persons pets.
        /// </summary>
        public IEnumerable<Pet> Pets { get; }
    }
}
