// <copyright file="IGetRootsById.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using NMediation.Abstractions;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IGetRootsById<TRoot> : IGetRootsById<TRoot, Guid, IOccurrence>
        where TRoot : IAggregateRoot
    {
    }
}
