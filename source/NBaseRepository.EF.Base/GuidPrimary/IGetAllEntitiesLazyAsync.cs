// <copyright file="IGetAllEntitiesLazyAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using NBaseRepository.EF.Base.Common;
using NBaseRepository.GuidPrimary;

namespace NBaseRepository.EF.Base.GuidPrimary
{
    /// <summary>
    /// An interface used to describe a class that retrieves all entities both lazily and asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetAllEntitiesLazyAsync<TEntity> : IGetAllEntitiesLazyAsync<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}
