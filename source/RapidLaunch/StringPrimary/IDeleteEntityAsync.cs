// <copyright file="IDeleteEntityAsync.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IDeleteEntityAsync<in TEntity> : IDeleteEntityAsync<TEntity, string>
        where TEntity : IAggregateRoot
    {
    }
}
