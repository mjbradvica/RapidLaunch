// <copyright file="ISearchRootsAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface ISearchRootsAsync<TRoot> : ISearchRootsAsync<TRoot, string>
        where TRoot : class, IAggregateRoot
    {
    }
}
