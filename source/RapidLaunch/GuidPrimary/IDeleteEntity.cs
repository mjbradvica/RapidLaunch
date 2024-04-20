// <copyright file="IDeleteEntity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IDeleteEntity<in TEntity> : IDeleteEntity<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
