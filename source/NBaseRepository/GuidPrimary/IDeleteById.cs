// <copyright file="IDeleteById.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using NBaseRepository.Common;

namespace NBaseRepository.GuidPrimary
{
    /// <summary>
    /// An interface used to describe a class that can delete an entity by <see cref="Guid"/>.
    /// </summary>
    public interface IDeleteById : IDeleteById<Guid>
    {
    }
}