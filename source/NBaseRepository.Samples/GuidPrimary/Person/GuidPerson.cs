// <copyright file="GuidPerson.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.GuidPrimary;
using NBaseRepository.Samples.GuidPrimary.Animal;

namespace NBaseRepository.Samples.GuidPrimary.Person
{
    /// <summary>
    /// Sample entity.
    /// </summary>
    public class GuidPerson : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidPerson"/> class.
        /// </summary>
        /// <param name="name">The name of the person.</param>
        /// <param name="age">The age of the person.</param>
        /// <param name="guidAnimal">The pet of the person.</param>
        public GuidPerson(string name, int age, GuidAnimal guidAnimal)
            : this(Guid.NewGuid(), name, age, guidAnimal)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuidPerson"/> class.
        /// </summary>
        /// <param name="id">The identifier of the person.</param>
        /// <param name="name">The name of the person.</param>
        /// <param name="age">Teh age of the person.</param>
        /// <param name="guidAnimal">The pet of the person.</param>
        public GuidPerson(Guid id, string name, int age, GuidAnimal guidAnimal)
        {
            Id = id;
            Name = name;
            Age = age;
            GuidAnimal = guidAnimal;
        }

        /// <inheritdoc/>
        public Guid Id { get; }

        /// <summary>
        /// Gets the name of the person.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the age of the person.
        /// </summary>
        public int Age { get; }

        /// <summary>
        /// Gets the pet of the person.
        /// </summary>
        public GuidAnimal GuidAnimal { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Age: {Age} Pet: {GuidAnimal.Name} \n";
        }
    }
}
