﻿// <copyright file="IAddRoot.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IAddRoot<in TRoot> : IAddRoot<TRoot, long>
        where TRoot : IAggregateRoot
    {
    }
}
