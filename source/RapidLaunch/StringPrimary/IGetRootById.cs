// <copyright file="IGetRootById.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IGetRootById<out TEntity> : IGetRootById<TEntity, string>
        where TEntity : IAggregateRoot
    {
    }
}
