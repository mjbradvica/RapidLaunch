// <copyright file="IGetAllEntities.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IGetAllEntities<TEntity> : IGetAllEntities<TEntity, long>
        where TEntity : IAggregateRoot
    {
    }
}
