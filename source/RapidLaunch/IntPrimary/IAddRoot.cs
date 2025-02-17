// <copyright file="IAddRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IAddRoot<in TRoot> : IAddRoot<TRoot, int>
        where TRoot : IAggregateRoot
    {
    }
}
