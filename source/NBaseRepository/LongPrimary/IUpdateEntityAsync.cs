// <copyright file="IUpdateEntityAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Common;

namespace NBaseRepository.LongPrimary
{
    /// <summary>
    /// An interface used to describe a class that can update an entity asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IUpdateEntityAsync<in TEntity> : IUpdateEntityAsync<TEntity, long>
        where TEntity : IEntity
    {
    }
}
