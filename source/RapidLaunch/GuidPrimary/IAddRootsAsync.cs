// <copyright file="IAddRootsAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IAddRootsAsync<in TEntity> : IAddRootsAsync<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
