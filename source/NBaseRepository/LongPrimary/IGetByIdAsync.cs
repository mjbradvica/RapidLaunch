// <copyright file="IGetByIdAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Common;

namespace NBaseRepository.LongPrimary
{
    /// <summary>
    /// An interface used to describe a class that can retrieve an identify by a <see cref="long"/> identifier asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetByIdAsync<TEntity> : IGetByIdAsync<TEntity, long>
        where TEntity : IEntity
    {
    }
}
