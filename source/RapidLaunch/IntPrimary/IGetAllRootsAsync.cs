// <copyright file="IGetAllRootsAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IGetAllRootsAsync<TEntity> : IGetAllRootsAsync<TEntity, int>
        where TEntity : IAggregateRoot
    {
    }
}
