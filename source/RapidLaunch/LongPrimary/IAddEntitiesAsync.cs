// <copyright file="IAddEntitiesAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IAddEntitiesAsync<in TEntity> : IAddEntitiesAsync<TEntity, long>
        where TEntity : IAggregateRoot
    {
    }
}
