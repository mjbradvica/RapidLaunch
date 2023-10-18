// <copyright file="Person.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.IntPrimary;

namespace NBaseRepository.Tests.Common.IntPrimary
{
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
