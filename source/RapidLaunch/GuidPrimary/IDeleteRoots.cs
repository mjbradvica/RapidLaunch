// <copyright file="IDeleteRoots.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IDeleteRoots<in TRoot> : IDeleteRoots<TRoot, Guid>
        where TRoot : IAggregateRoot
    {
    }
}
