// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using System.Linq;
using ClearDomain.StringPrimary;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.Common;

namespace RapidLaunch.EF.StringPrimary
{
    /// <inheritdoc />
    public class RapidLaunchRepository<TEntity> : RapidLaunchRepository<TEntity, string>
        where TEntity : class, IAggregateRoot
    {
        /// <inheritdoc />
        public RapidLaunchRepository(DbContext context, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeFunc = default)
            : base(context, includeFunc)
        {
        }

        /// <inheritdoc />
        public RapidLaunchRepository(DbContext context)
            : base(context)
        {
        }
    }
}
