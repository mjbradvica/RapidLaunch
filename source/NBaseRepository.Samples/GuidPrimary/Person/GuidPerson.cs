// <copyright file="GuidPerson.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Samples.GuidPrimary.Person
{
    using NBaseRepository.Samples.GuidPrimary.Animal;
    using NBaseRepository.GuidPrimary;

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
