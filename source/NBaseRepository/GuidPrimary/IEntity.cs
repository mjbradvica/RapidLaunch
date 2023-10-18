// <copyright file="IEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.GuidPrimary
{
    using System;
    using NBaseRepository.Common;

    /// <summary>
    /// An interface used to describe a class that has an Id of type <see cref="Guid"/>.
    /// </summary>
    public interface IEntity : IEntity<Guid>
    {
    }
}
