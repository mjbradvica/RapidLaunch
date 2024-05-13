// <copyright file="IDeleteEntity.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public interface IDeleteEntity<in TEntity> : IDeleteEntity<TEntity, long>
        where TEntity : IAggregateRoot
    {
    }
}
