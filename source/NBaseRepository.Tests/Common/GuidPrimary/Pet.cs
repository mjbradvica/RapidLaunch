// <copyright file="Pet.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using NBaseRepository.GuidPrimary;

namespace NBaseRepository.Tests.Common.GuidPrimary
{
    /// <summary>
    /// Test entity for <see cref="Guid"/> relationships.
    /// </summary>
    internal class Pet : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pet"/> class.
        /// </summary>
        public Pet()
        {
            Id = Guid.NewGuid();
        }

        /// <inheritdoc/>
        public Guid Id { get; }
    }
}
