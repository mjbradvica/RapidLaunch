// <copyright file="IGetByIdAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Common;

namespace NBaseRepository.IntPrimary
{
    /// <summary>
    /// An interface used to describe a class that can retrieve a single entity by an <see cref="int"/> identifier.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetByIdAsync<TEntity> : IGetByIdAsync<TEntity, int>
        where TEntity : IEntity
    {
    }
}
