﻿// <copyright file="IDeleteRootsAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IDeleteRootsAsync<in TRoot> : IDeleteRootsAsync<TRoot, int>
        where TRoot : IAggregateRoot
    {
    }
}
