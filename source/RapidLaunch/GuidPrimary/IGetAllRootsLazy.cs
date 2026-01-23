// <copyright file="IGetAllRootsLazy.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using ClearDomain.GuidPrimary;
using NMediation.Abstractions;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IGetAllRootsLazy<out TRoot> : IGetAllRootsLazy<TRoot, Guid, IOccurrence>
        where TRoot : IAggregateRoot
    {
    }
}
