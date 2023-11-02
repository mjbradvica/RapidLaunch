// <copyright file="IAddEntitiesAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Common;

namespace NBaseRepository.LongPrimary
{
    /// <summary>
    /// An interface used to describe a class that can add multiple entities asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAddEntitiesAsync<in TEntity> : IAddEntitiesAsync<TEntity, long>
        where TEntity : IEntity
    {
    }
}
