// <copyright file="IGetEntitiesById.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IGetEntitiesById<TEntity> : IGetEntitiesById<TEntity, int>
        where TEntity : IAggregateRoot
    {
    }
}
