﻿// <copyright file="IGetAllEntitiesAsync.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IGetAllEntitiesAsync<TEntity> : IGetAllEntitiesAsync<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
