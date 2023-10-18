// <copyright file="Person.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.LongPrimary;

namespace NBaseRepository.Tests.Common.LongPrimary
{
    internal class Person : IEntity
    {
        public Person(long id)
        {
            Id = id;
        }

        /// <inheritdoc/>
        public long Id { get; }
    }
}
