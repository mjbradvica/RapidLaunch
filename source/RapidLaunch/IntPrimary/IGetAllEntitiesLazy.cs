// <copyright file="IGetAllEntitiesLazy.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.IntPrimary
{
    /// <inheritdoc />
    public interface IGetAllEntitiesLazy<out TEntity> : IGetAllEntitiesLazy<TEntity, int>
        where TEntity : IAggregateRoot
    {
    }
}
