// <copyright file="IUpdateRootsAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using NMediation.Abstractions;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IUpdateRootsAsync<in TRoot> : IUpdateRootAsync<TRoot, string, IOccurrence>
        where TRoot : IAggregateRoot
    {
    }
}
