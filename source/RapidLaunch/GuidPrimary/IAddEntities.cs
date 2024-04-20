// <copyright file="IAddEntities.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IAddEntities<in TEntity> : IAddEntities<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
