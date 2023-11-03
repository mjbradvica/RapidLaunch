// <copyright file="Person.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.IntPrimary;

namespace NBaseRepository.Tests.IntPrimary
{
    /// <summary>
    /// Test entity for classes with <see cref="int"/> primary keys.
    /// </summary>
    public class Person : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
            Id = 123;
        }

        /// <inheritdoc/>
        public int Id { get; }
    }
}
