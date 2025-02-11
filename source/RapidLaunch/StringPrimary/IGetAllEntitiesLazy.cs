// <copyright file="IGetAllEntitiesLazy.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IGetAllEntitiesLazy<out TEntity> : IGetAllEntitiesLazy<TEntity, string>
        where TEntity : IAggregateRoot
    {
    }
}
