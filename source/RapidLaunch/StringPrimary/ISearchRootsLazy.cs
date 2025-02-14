// <copyright file="ISearchRootsLazy.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface ISearchRootsLazy<TEntity> : ISearchRootsLazy<TEntity, string>
        where TEntity : class, IAggregateRoot
    {
    }
}
