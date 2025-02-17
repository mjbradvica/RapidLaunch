// <copyright file="IGetRootById.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IGetRootById<out TRoot> : IGetRootById<TRoot, long>
        where TRoot : IAggregateRoot
    {
    }
}
