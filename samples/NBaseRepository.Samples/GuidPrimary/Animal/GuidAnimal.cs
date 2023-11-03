// <copyright file="GuidAnimal.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.GuidPrimary;

namespace NBaseRepository.Samples.GuidPrimary.Animal
{
    /// <summary>
    /// Sample entity.
    /// </summary>
    public class GuidAnimal : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidAnimal"/> class.
        /// </summary>
        /// <param name="name">The animal name.</param>
        public GuidAnimal(string name)
            : this(Guid.NewGuid(), name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuidAnimal"/> class.
        /// </summary>
        /// <param name="id">The pet identifier.</param>
        /// <param name="name">The pet name.</param>
        public GuidAnimal(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <inheritdoc/>
        public Guid Id { get; }

        /// <summary>
        /// Gets the pets name.
        /// </summary>
        public string Name { get; }
    }
}
