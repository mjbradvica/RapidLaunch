// <copyright file="IGetAllEntitiesLazy.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using NBaseRepository.EF.Base.Common;
using NBaseRepository.GuidPrimary;

namespace NBaseRepository.EF.Base.GuidPrimary
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all entity of type <see cref="TEntity"/> lazily.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetAllEntitiesLazy<TEntity> : IGetAllEntitiesLazy<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}
