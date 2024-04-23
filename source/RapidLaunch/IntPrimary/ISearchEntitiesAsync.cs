// <copyright file="ISearchEntitiesAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface ISearchEntitiesAsync<TEntity> : ISearchEntitiesAsync<TEntity, int>
        where TEntity : class, IAggregateRoot
    {
    }
}
