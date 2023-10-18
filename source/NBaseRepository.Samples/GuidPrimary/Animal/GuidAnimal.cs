// <copyright file="GuidAnimal.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Samples.GuidPrimary.Animal
{
    using NBaseRepository.GuidPrimary;

    public class GuidAnimal : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidAnimal"/> class.
        /// </summary>
        /// <param name="name"></param>
        public GuidAnimal(string name)
            : this(Guid.NewGuid(), name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuidAnimal"/> class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public GuidAnimal(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <inheritdoc/>
        public Guid Id { get; }

        public string Name { get; }
    }
}
