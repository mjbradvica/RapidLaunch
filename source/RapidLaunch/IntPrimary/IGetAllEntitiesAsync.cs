﻿// <copyright file="IGetAllEntitiesAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IGetAllEntitiesAsync<TEntity> : IGetAllEntitiesAsync<TEntity, int>
        where TEntity : IAggregateRoot
    {
    }
}
