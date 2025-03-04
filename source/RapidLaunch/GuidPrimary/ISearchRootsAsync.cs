﻿// <copyright file="ISearchRootsAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface ISearchRootsAsync<TRoot> : ISearchRootsAsync<TRoot, Guid>
        where TRoot : class, IAggregateRoot
    {
    }
}
