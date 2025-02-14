// <copyright file="IUpdateRootAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IUpdateRootAsync<in TEntity> : IUpdateRootAsync<TEntity, long>
        where TEntity : IAggregateRoot
    {
    }
}
