// <copyright file="IDeleteRootAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IDeleteRootAsync<in TEntity> : IDeleteRootAsync<TEntity, int>
        where TEntity : IAggregateRoot
    {
    }
}
