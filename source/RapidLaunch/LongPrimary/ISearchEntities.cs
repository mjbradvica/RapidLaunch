// <copyright file="ISearchEntities.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface ISearchEntities<TEntity> : ISearchEntities<TEntity, long>
        where TEntity : class, IAggregateRoot
    {
    }
}
