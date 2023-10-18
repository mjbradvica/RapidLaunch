// <copyright file="NBaseRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Data.SqlClient;
using NBaseRepository.ADO.Common;
using NBaseRepository.Common;
using NBaseRepository.GuidPrimary;

namespace NBaseRepository.ADO.GuidPrimary
{
    public abstract class NBaseRepository<TEntity> : NBaseCoreRepository<TEntity, Guid>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="conversionFunc"></param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, Guid> sqlBuilder, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlConnection, sqlBuilder, conversionFunc)
        {
        }
    }
}
