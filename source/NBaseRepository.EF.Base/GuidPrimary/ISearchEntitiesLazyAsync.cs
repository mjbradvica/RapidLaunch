// <copyright file="ISearchEntitiesLazyAsync.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.EF.Base.GuidPrimary
{
    using System;
    using NBaseRepository.EF.Base.Common;
    using NBaseRepository.GuidPrimary;

    internal interface ISearchEntitiesLazyAsync<TEntity> : ISearchEntitiesLazyAsync<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}
