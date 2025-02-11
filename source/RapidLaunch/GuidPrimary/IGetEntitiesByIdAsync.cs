// <copyright file="IGetEntitiesByIdAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IGetEntitiesByIdAsync<TEntity> : IGetEntitiesByIdAsync<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
