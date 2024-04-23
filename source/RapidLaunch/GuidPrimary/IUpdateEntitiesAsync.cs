// <copyright file="IUpdateEntitiesAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IUpdateEntitiesAsync<in TEntity> : IUpdateEntityAsync<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
