// <copyright file="IAddEntityAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Common;

namespace NBaseRepository.LongPrimary
{
    /// <summary>
    /// An interface that allows a class to add a single entity asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAddEntityAsync<in TEntity> : IAddEntityAsync<TEntity, long>
        where TEntity : IEntity
    {
    }
}
