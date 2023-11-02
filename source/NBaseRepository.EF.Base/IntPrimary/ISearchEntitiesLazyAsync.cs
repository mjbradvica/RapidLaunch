// <copyright file="ISearchEntitiesLazyAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.EF.Base.Common;
using NBaseRepository.IntPrimary;

namespace NBaseRepository.EF.Base.IntPrimary
{
    /// <inheritdoc />
    public interface ISearchEntitiesLazyAsync<TEntity> : ISearchEntitiesLazyAsync<TEntity, int>
        where TEntity : IEntity
    {
    }
}
