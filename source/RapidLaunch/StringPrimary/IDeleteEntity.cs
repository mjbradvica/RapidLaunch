// <copyright file="IDeleteEntity.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IDeleteEntity<in TEntity> : IDeleteEntity<TEntity, string>
        where TEntity : IAggregateRoot
    {
    }
}
