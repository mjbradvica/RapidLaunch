// <copyright file="IUpdateEntitiesAsync.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
	/// <inheritdoc />
	public interface IUpdateEntitiesAsync<in TEntity> : IUpdateEntityAsync<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
