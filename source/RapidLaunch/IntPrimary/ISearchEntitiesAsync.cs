// <copyright file="ISearchEntitiesAsync.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface ISearchEntitiesAsync<TEntity> : ISearchEntitiesAsync<TEntity, int>
        where TEntity : class, IAggregateRoot
    {
    }
}
