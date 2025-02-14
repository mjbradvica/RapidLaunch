// <copyright file="IGetRootsByIdAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IGetRootsByIdAsync<TEntity> : IGetRootsByIdAsync<TEntity, long>
        where TEntity : IAggregateRoot
    {
    }
}
