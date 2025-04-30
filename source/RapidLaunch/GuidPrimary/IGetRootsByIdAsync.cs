// <copyright file="IGetRootsByIdAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IGetRootsByIdAsync<TRoot> : IGetRootsByIdAsync<TRoot, Guid, IDomainEvent>
        where TRoot : IAggregateRoot
    {
    }
}
