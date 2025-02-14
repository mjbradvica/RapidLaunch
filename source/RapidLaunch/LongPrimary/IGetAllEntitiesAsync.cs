// <copyright file="IGetAllEntitiesAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IGetAllRootsAsync<TEntity> : IGetAllRootsAsync<TEntity, long>
        where TEntity : IAggregateRoot
    {
    }
}
