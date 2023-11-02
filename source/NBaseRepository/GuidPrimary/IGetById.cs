﻿// <copyright file="IGetById.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using NBaseRepository.Common;

namespace NBaseRepository.GuidPrimary
{
    /// <summary>
    /// An interface used to describe a class that can retrieve a single entity by a <see cref="Guid"/> identifier.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetById<out TEntity> : IGetById<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}