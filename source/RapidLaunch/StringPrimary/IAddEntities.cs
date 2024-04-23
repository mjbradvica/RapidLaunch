// <copyright file="IAddEntities.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IAddEntities<in TEntity> : IAddEntities<TEntity, string>
        where TEntity : IAggregateRoot
    {
    }
}
