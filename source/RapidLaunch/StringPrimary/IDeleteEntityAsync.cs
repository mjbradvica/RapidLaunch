// <copyright file="IDeleteEntityAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IDeleteEntityAsync<in TEntity> : IDeleteEntityAsync<TEntity, string>
        where TEntity : IAggregateRoot
    {
    }
}
