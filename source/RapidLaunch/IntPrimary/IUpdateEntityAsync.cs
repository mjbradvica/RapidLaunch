// <copyright file="IUpdateEntityAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IUpdateEntityAsync<in TEntity> : IUpdateEntityAsync<TEntity, int>
        where TEntity : IAggregateRoot
    {
    }
}
