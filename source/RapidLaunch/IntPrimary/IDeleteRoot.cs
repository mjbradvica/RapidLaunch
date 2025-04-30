// <copyright file="IDeleteRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IDeleteRoot<in TRoot> : IDeleteRoot<TRoot, int, IDomainEvent>
        where TRoot : IAggregateRoot
    {
    }
}
