// <copyright file="IUpdateEntity.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
	/// <inheritdoc />
	public interface IUpdateEntity<in TEntity> : IUpdateEntity<TEntity, Guid>
        where TEntity : IAggregateRoot
    {
    }
}
