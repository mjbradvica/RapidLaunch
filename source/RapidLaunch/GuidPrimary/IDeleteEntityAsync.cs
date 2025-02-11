// <copyright file="IDeleteEntityAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IDeleteEntityAsync<in TEntity> : IDeleteEntityAsync<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
