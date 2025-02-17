// <copyright file="IDeleteRoots.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IDeleteRoots<in TRoot> : IDeleteRoots<TRoot, string>
        where TRoot : IAggregateRoot
    {
    }
}
