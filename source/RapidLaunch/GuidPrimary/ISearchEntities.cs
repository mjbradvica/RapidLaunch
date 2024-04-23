// <copyright file="ISearchEntities.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface ISearchEntities<TEntity> : ISearchEntities<TEntity, Guid>
        where TEntity : class, IAggregateRoot
    {
    }
}
