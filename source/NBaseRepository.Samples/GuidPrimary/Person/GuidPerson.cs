// <copyright file="GuidPerson.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Samples.GuidPrimary.Animal;
using NBaseRepository.GuidPrimary;

namespace NBaseRepository.Samples.GuidPrimary.Person
{
    public class GuidPerson : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidPerson"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="guidAnimal"></param>
        public GuidPerson(string name, int age, GuidAnimal guidAnimal)
            : this(Guid.NewGuid(), name, age, guidAnimal)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuidPerson"/> class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="guidAnimal"></param>
        public GuidPerson(Guid id, string name, int age, GuidAnimal guidAnimal)
        {
            Id = id;
            Name = name;
            Age = age;
            GuidAnimal = guidAnimal;
        }

        /// <inheritdoc/>
        public Guid Id { get; }

        public string Name { get; }

        public int Age { get; }

        public GuidAnimal GuidAnimal { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Age: {Age} Pet: {GuidAnimal.Name} \n";
        }
    }
}
