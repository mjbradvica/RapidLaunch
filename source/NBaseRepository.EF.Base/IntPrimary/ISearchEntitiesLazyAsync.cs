// <copyright file="ISearchEntitiesLazyAsync.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.EF.Base.IntPrimary
{
    using NBaseRepository.EF.Base.Common;
    using NBaseRepository.IntPrimary;

    internal interface ISearchEntitiesLazyAsync<TEntity> : ISearchEntitiesLazyAsync<TEntity, int>
        where TEntity : IEntity
    {
    }
}
