// <copyright file="IDeleteEntities.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public interface IDeleteEntities<in TEntity> : IDeleteEntities<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
