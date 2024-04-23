// <copyright file="ISearchEntitiesLazy.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface ISearchEntitiesLazy<TEntity> : ISearchEntitiesLazy<TEntity, long>
        where TEntity : class, IAggregateRoot
    {
    }
}
