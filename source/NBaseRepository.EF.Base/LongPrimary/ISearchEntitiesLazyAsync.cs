// <copyright file="ISearchEntitiesLazyAsync.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.EF.Base.LongPrimary
{
    using NBaseRepository.EF.Base.Common;
    using NBaseRepository.LongPrimary;

    internal interface ISearchEntitiesLazyAsync<TEntity> : ISearchEntitiesLazyAsync<TEntity, long>
        where TEntity : IEntity
    {
    }
}
