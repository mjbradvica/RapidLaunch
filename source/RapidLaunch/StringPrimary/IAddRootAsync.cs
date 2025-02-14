// <copyright file="IAddRootAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IAddRootAsync<in TEntity> : IAddRootAsync<TEntity, string>
        where TEntity : IAggregateRoot
    {
    }
}
