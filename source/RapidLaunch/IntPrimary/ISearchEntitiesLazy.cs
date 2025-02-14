﻿// <copyright file="ISearchEntitiesLazy.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface ISearchRootsLazy<TEntity> : ISearchRootsLazy<TEntity, int>
        where TEntity : class, IAggregateRoot
    {
    }
}
