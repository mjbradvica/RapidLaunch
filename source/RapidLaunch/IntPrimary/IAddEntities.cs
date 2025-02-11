﻿// <copyright file="IAddEntities.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IAddEntities<in TEntity> : IAddEntities<TEntity, int>
        where TEntity : IAggregateRoot
    {
    }
}
