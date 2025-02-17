// <copyright file="IUpdateRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IUpdateRoot<in TRoot> : IUpdateRoot<TRoot, long>
        where TRoot : IAggregateRoot
    {
    }
}
