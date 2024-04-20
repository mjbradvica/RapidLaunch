// <copyright file="IUpdateEntities.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IUpdateEntities<in TEntity> : IUpdateEntities<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
