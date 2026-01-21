// <copyright file="ISearchRootsLazy.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using NMediation.Abstractions;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface ISearchRootsLazy<TRoot> : ISearchRootsLazy<TRoot, int, IOccurrence>
        where TRoot : class, IAggregateRoot
    {
    }
}
