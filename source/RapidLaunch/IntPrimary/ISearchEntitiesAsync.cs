// <copyright file="ISearchEntitiesAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface ISearchRootsAsync<TEntity> : ISearchRootsAsync<TEntity, int>
        where TEntity : class, IAggregateRoot
    {
    }
}
