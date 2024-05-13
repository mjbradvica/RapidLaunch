// <copyright file="IAddEntityAsync.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IAddEntityAsync<in TEntity> : IAddEntityAsync<TEntity, int>
        where TEntity : IAggregateRoot
    {
    }
}
