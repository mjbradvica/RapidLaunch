// <copyright file="IAddRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IAddRoot<in TRoot> : IAddRoot<TRoot, int, IDomainEvent>
        where TRoot : IAggregateRoot
    {
    }
}
