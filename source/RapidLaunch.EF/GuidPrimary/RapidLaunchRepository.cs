// <copyright file="RapidLaunchRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Linq;
using ClearDomain.GuidPrimary;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.Common;

namespace RapidLaunch.EF.GuidPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchRepository<TEntity> : RapidLaunchRepository<TEntity, Guid>
        where TEntity : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchRepository(DbContext context, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeFunc = default)
            : base(context, includeFunc)
        {
        }

        /// <inheritdoc />
        protected RapidLaunchRepository(DbContext context)
            : base(context)
        {
        }
    }
}
