﻿// <copyright file="IQuery.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IQuery<TRoot> : IQuery<TRoot, string>
        where TRoot : class, IAggregateRoot
    {
    }
}
