// <copyright file="IGetAllEntitiesLazyAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.EF.Base.Common;
using NBaseRepository.LongPrimary;

namespace NBaseRepository.EF.Base.LongPrimary
{
    internal interface IGetAllEntitiesLazyAsync<TEntity> : IGetAllEntitiesLazyAsync<TEntity, long>
        where TEntity : IEntity
    {
    }
}
