// <copyright file="IGetByIdAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IGetRootByIdAsync<TEntity> : IGetRootByIdAsync<TEntity, long>
        where TEntity : IAggregateRoot
    {
    }
}
