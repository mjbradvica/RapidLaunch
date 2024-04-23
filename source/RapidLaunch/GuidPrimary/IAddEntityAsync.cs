// <copyright file="IAddEntityAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IAddEntityAsync<in TEntity> : IAddEntityAsync<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
