﻿// <copyright file="IGetRootsByIdAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IGetRootsByIdAsync<TRoot> : IGetRootsByIdAsync<TRoot, int>
        where TRoot : IAggregateRoot
    {
    }
}
