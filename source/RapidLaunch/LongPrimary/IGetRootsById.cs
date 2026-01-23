// <copyright file="IGetRootsById.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using NMediation.Abstractions;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IGetRootsById<TRoot> : IGetRootsById<TRoot, long, IOccurrence>
        where TRoot : IAggregateRoot
    {
    }
}
