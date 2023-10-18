// <copyright file="IAddEntities.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using NBaseRepository.Common;

namespace NBaseRepository.GuidPrimary
{
    /// <summary>
    /// An interface used to describe a class that can add multiple entities of type <see cref="TEntity"/> at one time.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAddEntities<in TEntity> : IAddEntities<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}