// <copyright file="Person.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.IntPrimary;

namespace NBaseRepository.Tests.Common.IntPrimary
{
    /// <summary>
    /// Test entity for <see cref="int"/> entities.
    /// </summary>
    internal class Person : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        public Person(int id)
        {
            Id = id;
        }

        /// <inheritdoc/>
        public int Id { get; }
    }
}
