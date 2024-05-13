// <copyright file="IGetAllEntitiesAsync.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IGetAllEntitiesAsync<TEntity> : IGetAllEntitiesAsync<TEntity, string>
        where TEntity : IAggregateRoot
    {
    }
}
