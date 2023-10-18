// <copyright file="Pet.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using NBaseRepository.GuidPrimary;

namespace NBaseRepository.Tests.Common.GuidPrimary
{
    internal class Pet : IEntity
    {
        public Pet()
        {
            Id = Guid.NewGuid();
        }

        /// <inheritdoc/>
        public Guid Id { get; }
    }
}
