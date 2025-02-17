﻿// <copyright file="ISearchRoots.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface ISearchRoots<TRoot> : ISearchRoots<TRoot, long>
        where TRoot : class, IAggregateRoot
    {
    }
}
