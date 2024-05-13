﻿// <copyright file="IAddEntitiesAsync.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IAddEntitiesAsync<in TEntity> : IAddEntitiesAsync<TEntity, long>
        where TEntity : IAggregateRoot
    {
    }
}
