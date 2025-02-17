// <copyright file="IAddRoots.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IAddRoots<in TRoot> : IAddRoots<TRoot, long>
        where TRoot : IAggregateRoot
    {
    }
}
