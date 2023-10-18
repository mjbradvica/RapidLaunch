// <copyright file="GuidAnimal.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.GuidPrimary;

namespace NBaseRepository.Samples.GuidPrimary.Animal
{
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
