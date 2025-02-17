// <copyright file="IGetAllRootsLazy.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IGetAllRootsLazy<out TRoot> : IGetAllRootsLazy<TRoot, long>
        where TRoot : IAggregateRoot
    {
    }
}
