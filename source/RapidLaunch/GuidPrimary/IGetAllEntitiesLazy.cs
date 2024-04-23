// <copyright file="IGetAllEntitiesLazy.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IGetAllEntitiesLazy<out TEntity> : IGetAllEntitiesLazy<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
