// <copyright file="IAddRootsAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IAddRootsAsync<in TRoot> : IAddRootsAsync<TRoot, long>
        where TRoot : IAggregateRoot
    {
    }
}
