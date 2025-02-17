// <copyright file="IUpdateRootAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IUpdateRootAsync<in TRoot> : IUpdateRootAsync<TRoot, long>
        where TRoot : IAggregateRoot
    {
    }
}
