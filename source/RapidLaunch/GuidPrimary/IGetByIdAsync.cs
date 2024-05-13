﻿// <copyright file="IGetByIdAsync.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IGetByIdAsync<TEntity> : IGetByIdAsync<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
