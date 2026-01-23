// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using Microsoft.Data.SqlClient;
using NMediation.Abstractions;
using RapidLaunch.Dapper.Common;

namespace RapidLaunch.Dapper.StringPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchRepository<TRoot> : RapidLaunchRepository<TRoot, string, IOccurrence>
        where TRoot : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchRepository(SqlConnection connection)
            : base(connection)
        {
        }
    }
}
