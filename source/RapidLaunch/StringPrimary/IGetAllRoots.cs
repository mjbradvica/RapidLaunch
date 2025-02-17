// <copyright file="IGetAllRoots.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IGetAllRoots<TRoot> : IGetAllRoots<TRoot, string>
        where TRoot : IAggregateRoot
    {
    }
}
