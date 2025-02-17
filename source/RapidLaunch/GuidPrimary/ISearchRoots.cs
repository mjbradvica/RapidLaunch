// <copyright file="ISearchRoots.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface ISearchRoots<TRoot> : ISearchRoots<TRoot, Guid>
        where TRoot : class, IAggregateRoot
    {
    }
}
