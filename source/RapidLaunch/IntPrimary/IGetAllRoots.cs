// <copyright file="IGetAllRoots.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using ClearDomain.IntPrimary;
using NMediation.Abstractions;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IGetAllRoots<TRoot> : IGetAllRoots<TRoot, int, IOccurrence>
        where TRoot : IAggregateRoot
    {
    }
}
