// <copyright file="IUpdateRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IUpdateRoot<in TRoot> : IUpdateRoot<TRoot, Guid, IDomainEvent>
        where TRoot : IAggregateRoot
    {
    }
}
