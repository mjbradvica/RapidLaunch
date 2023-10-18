// <copyright file="Person.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using NBaseRepository.GuidPrimary;

namespace NBaseRepository.Tests.GuidPrimary
{
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
