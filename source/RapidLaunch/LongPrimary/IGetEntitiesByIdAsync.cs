// <copyright file="IGetEntitiesByIdAsync.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IGetEntitiesByIdAsync<TEntity> : IGetEntitiesByIdAsync<TEntity, long>
        where TEntity : IAggregateRoot
    {
    }
}
