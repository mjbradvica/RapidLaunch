// <copyright file="IUpdateEntity.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IUpdateEntity<in TEntity> : IUpdateEntity<TEntity, int>
        where TEntity : IAggregateRoot
    {
    }
}
