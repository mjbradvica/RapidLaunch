// <copyright file="IGetAllEntitiesLazyAsync.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.EF.Base.IntPrimary
{
    using NBaseRepository.EF.Base.Common;
    using NBaseRepository.IntPrimary;

    internal interface IGetAllEntitiesLazyAsync<TEntity> : IGetAllEntitiesLazyAsync<TEntity, int>
        where TEntity : IEntity
    {
    }
}
