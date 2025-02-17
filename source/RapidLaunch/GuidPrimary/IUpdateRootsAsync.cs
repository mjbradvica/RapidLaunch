// <copyright file="IUpdateRootsAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IUpdateRootsAsync<in TRoot> : IUpdateRootAsync<TRoot, Guid>
        where TRoot : IAggregateRoot
    {
    }
}
