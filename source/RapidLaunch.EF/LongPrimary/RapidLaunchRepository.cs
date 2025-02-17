// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.Common;

namespace RapidLaunch.EF.LongPrimary
{
    /// <inheritdoc />
    public class RapidLaunchRepository<TRoot> : RapidLaunchRepository<TRoot, long>
        where TRoot : class, IAggregateRoot
    {
        /// <inheritdoc />
        public RapidLaunchRepository(DbContext context, Func<IQueryable<TRoot>, IQueryable<TRoot>>? includeFunc = null)
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
