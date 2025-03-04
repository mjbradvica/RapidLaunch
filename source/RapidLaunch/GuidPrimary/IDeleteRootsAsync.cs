﻿// <copyright file="IDeleteRootsAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IDeleteRootsAsync<in TRoot> : IDeleteRootsAsync<TRoot, Guid>
        where TRoot : IAggregateRoot
    {
    }
}
