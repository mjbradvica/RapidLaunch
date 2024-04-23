// <copyright file="IGetById.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IGetById<out TEntity> : IGetById<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
