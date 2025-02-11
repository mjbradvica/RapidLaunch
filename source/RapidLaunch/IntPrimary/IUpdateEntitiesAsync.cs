﻿// <copyright file="IUpdateEntitiesAsync.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IUpdateEntitiesAsync<in TEntity> : IUpdateEntityAsync<TEntity, int>
        where TEntity : IAggregateRoot
    {
    }
}
