// <copyright file="IGetAllEntitiesLazyAsync.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.EF.Base.GuidPrimary
{
    using System;
    using NBaseRepository.EF.Base.Common;
    using NBaseRepository.GuidPrimary;

    public interface IGetAllEntitiesLazyAsync<TEntity> : IGetAllEntitiesLazyAsync<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}
