// <copyright file="IGetEntitiesById.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IGetEntitiesById<TEntity> : IGetEntitiesById<TEntity, string>
        where TEntity : IAggregateRoot
    {
    }
}
