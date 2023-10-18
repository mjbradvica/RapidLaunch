// <copyright file="Person.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Tests.GuidPrimary
{
    using System;
    using NBaseRepository.GuidPrimary;

    public class Person : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
            Id = Guid.NewGuid();
        }

        /// <inheritdoc/>
        public Guid Id { get; }
    }
}
