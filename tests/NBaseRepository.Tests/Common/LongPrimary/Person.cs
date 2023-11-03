// <copyright file="Person.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.LongPrimary;

namespace NBaseRepository.Tests.Common.LongPrimary
{
    /// <summary>
    /// Test entity for <see cref="long"/> entities.
    /// </summary>
    internal class Person : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        public Person(long id)
        {
            Id = id;
        }

        /// <inheritdoc/>
        public long Id { get; }
    }
}
