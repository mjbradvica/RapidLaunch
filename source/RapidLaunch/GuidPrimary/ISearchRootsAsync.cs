// <copyright file="ISearchRootsAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using NMediation.Abstractions;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface ISearchRootsAsync<TRoot> : ISearchRootsAsync<TRoot, Guid, IOccurrence>
        where TRoot : class, IAggregateRoot
    {
    }
}
