// <copyright file="IDeleteEntityAsync.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IDeleteEntityAsync<in TEntity> : IDeleteEntityAsync<TEntity, long>
        where TEntity : IAggregateRoot
    {
    }
}
