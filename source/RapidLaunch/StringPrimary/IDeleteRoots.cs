// <copyright file="IDeleteRoots.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IDeleteRoots<in TEntity> : IDeleteRoots<TEntity, string>
        where TEntity : IAggregateRoot
    {
    }
}
