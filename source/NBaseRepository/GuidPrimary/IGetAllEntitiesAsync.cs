﻿// <copyright file="IGetAllEntitiesAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using NBaseRepository.Common;

namespace NBaseRepository.GuidPrimary
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all entities asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetAllEntitiesAsync<TEntity> : IGetAllEntitiesAsync<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}
