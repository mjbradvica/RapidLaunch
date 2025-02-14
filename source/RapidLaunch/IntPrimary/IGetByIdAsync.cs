// <copyright file="IGetByIdAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IGetRootByIdAsync<TEntity> : IGetRootByIdAsync<TEntity, int>
        where TEntity : IAggregateRoot
    {
    }
}
