// <copyright file="IGetAllEntitiesLazyAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using NBaseRepository.EF.Base.Common;
using NBaseRepository.GuidPrimary;

namespace NBaseRepository.EF.Base.GuidPrimary
{
    public interface IGetAllEntitiesLazyAsync<TEntity> : IGetAllEntitiesLazyAsync<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}
