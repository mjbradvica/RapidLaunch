// <copyright file="Person.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Tests.IntPrimary
{
    using NBaseRepository.IntPrimary;

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
