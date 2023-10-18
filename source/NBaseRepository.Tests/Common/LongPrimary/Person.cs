// <copyright file="Person.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Tests.Common.LongPrimary
{
    using NBaseRepository.LongPrimary;

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
