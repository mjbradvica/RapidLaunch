// <copyright file="Person.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Tests.Common.IntPrimary
{
    using NBaseRepository.IntPrimary;

    internal class Person : IEntity
    {
        public Person(int id)
        {
            Id = id;
        }

        /// <inheritdoc/>
        public int Id { get; }
    }
}
