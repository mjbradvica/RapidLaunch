// <copyright file="IEntity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using NBaseRepository.Common;

namespace NBaseRepository.GuidPrimary
{
    /// <summary>
    /// An interface used to describe a class that has an Id of type <see cref="Guid"/>.
    /// </summary>
    public interface IEntity : IEntity<Guid>
    {
    }
}
