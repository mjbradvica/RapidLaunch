// <copyright file="IGetAllEntitiesAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IGetAllEntitiesAsync<TEntity> : IGetAllEntitiesAsync<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
