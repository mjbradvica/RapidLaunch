// <copyright file="IGetAllRootsAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IGetAllRootsAsync<TEntity> : IGetAllRootsAsync<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
