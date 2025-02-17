// <copyright file="IGetRootsById.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IGetRootsById<TRoot> : IGetRootsById<TRoot, string>
        where TRoot : IAggregateRoot
    {
    }
}
