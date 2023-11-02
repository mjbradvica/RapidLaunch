// <copyright file="IDeleteEntityAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Common;

namespace NBaseRepository.LongPrimary
{
    /// <summary>
    /// An interface used to describe a class that can delete an entity asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IDeleteEntityAsync<in TEntity> : IDeleteEntityAsync<TEntity, long>
        where TEntity : IEntity
    {
    }
}
