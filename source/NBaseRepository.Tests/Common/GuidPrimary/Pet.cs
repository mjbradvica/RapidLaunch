// <copyright file="Pet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Tests.Common.GuidPrimary
{
    using System;
    using NBaseRepository.GuidPrimary;

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
