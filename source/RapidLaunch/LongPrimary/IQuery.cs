// <copyright file="IQuery.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IQuery<TRoot> : IQuery<TRoot, long>
        where TRoot : class, IAggregateRoot
    {
    }
}
