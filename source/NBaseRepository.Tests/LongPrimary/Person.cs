// <copyright file="Person.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.LongPrimary;

namespace NBaseRepository.Tests.LongPrimary
{
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
        public long Id { get; }
    }
}
