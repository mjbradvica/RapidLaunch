// <copyright file="IDeleteEntity.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IDeleteEntity<in TEntity> : IDeleteEntity<TEntity, long>
        where TEntity : IAggregateRoot
    {
    }
}
