// <copyright file="ISearchEntitiesAsync.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface ISearchEntitiesAsync<TEntity> : ISearchEntitiesAsync<TEntity, long>
        where TEntity : class, IAggregateRoot
    {
    }
}
