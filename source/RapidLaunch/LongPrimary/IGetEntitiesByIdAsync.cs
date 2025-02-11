// <copyright file="IGetEntitiesByIdAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IGetEntitiesByIdAsync<TEntity> : IGetEntitiesByIdAsync<TEntity, long>
        where TEntity : IAggregateRoot
    {
    }
}
