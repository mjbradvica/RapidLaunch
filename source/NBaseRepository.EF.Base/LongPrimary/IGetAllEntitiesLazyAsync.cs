// <copyright file="IGetAllEntitiesLazyAsync.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.EF.Base.LongPrimary
{
    using NBaseRepository.EF.Base.Common;
    using NBaseRepository.LongPrimary;

    internal interface IGetAllEntitiesLazyAsync<TEntity> : IGetAllEntitiesLazyAsync<TEntity, long>
        where TEntity : IEntity
    {
    }
}
