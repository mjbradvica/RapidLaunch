// <copyright file="IGetAllRootsLazy.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IGetAllRootsLazy<out TRoot> : IGetAllRootsLazy<TRoot, Guid, IDomainEvent>
        where TRoot : IAggregateRoot
    {
    }
}
