// <copyright file="IGetRootsById.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IGetRootsById<TRoot> : IGetRootsById<TRoot, int>
        where TRoot : IAggregateRoot
    {
    }
}
