// <copyright file="ISearchEntitiesAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface ISearchEntitiesAsync<TEntity> : ISearchEntitiesAsync<TEntity, long>
        where TEntity : class, IAggregateRoot
    {
    }
}
