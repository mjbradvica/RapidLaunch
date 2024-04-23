// <copyright file="IGetAllEntities.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IGetAllEntities<TEntity> : IGetAllEntities<TEntity, int>
        where TEntity : IAggregateRoot
    {
    }
}
