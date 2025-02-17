// <copyright file="IDeleteRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IDeleteRoot<in TRoot> : IDeleteRoot<TRoot, int>
        where TRoot : IAggregateRoot
    {
    }
}
