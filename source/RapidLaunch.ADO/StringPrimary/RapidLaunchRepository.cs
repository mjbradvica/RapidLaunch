// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using Microsoft.Data.SqlClient;
using RapidLaunch.ADO.Common;

namespace RapidLaunch.ADO.StringPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchRepository<TRoot> : RapidLaunchRepository<TRoot, string>
        where TRoot : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchRepository(SqlConnection sqlConnection, Func<SqlDataReader, TRoot> conversionFunc)
            : base(sqlConnection, conversionFunc)
        {
        }
    }
}
