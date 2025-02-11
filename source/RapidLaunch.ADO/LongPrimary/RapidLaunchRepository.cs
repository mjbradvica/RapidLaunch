// <copyright file="RapidLaunchRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System.Data.SqlClient;
using ClearDomain.LongPrimary;
using RapidLaunch.ADO.Common;
using RapidLaunch.Common;

namespace RapidLaunch.ADO.LongPrimary
{
	/// <inheritdoc />
	public abstract class RapidLaunchRepository<TEntity> : RapidLaunchRepository<TEntity, long>
        where TEntity : class, IAggregateRoot
    {
		/// <inheritdoc />
		[Obsolete]
		protected RapidLaunchRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, long> sqlBuilder, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlConnection, sqlBuilder, conversionFunc)
        {
        }
    }
}
