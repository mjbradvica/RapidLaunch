// <copyright file="IUpdateEntity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IUpdateEntity<in TEntity> : IUpdateEntity<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
