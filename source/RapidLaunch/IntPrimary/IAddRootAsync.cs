// <copyright file="IAddRootAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IAddRootAsync<in TRoot> : IAddRootAsync<TRoot, int>
        where TRoot : IAggregateRoot
    {
    }
}
