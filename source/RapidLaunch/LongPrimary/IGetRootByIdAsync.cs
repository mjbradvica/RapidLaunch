// <copyright file="IGetRootByIdAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IGetRootByIdAsync<TRoot> : IGetRootByIdAsync<TRoot, long>
        where TRoot : IAggregateRoot
    {
    }
}
