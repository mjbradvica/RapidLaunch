﻿// <copyright file="IAddRootsAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IAddRootsAsync<in TRoot> : IAddRootsAsync<TRoot, string>
        where TRoot : IAggregateRoot
    {
    }
}
