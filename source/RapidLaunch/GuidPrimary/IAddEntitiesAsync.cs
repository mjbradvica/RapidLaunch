﻿// <copyright file="IAddEntitiesAsync.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IAddEntitiesAsync<in TEntity> : IAddEntitiesAsync<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
