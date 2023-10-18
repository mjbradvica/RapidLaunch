// <copyright file="NBaseRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.ADO.IntPrimary
{
    using System;
    using System.Data.SqlClient;
    using NBaseRepository.ADO.Common;
    using NBaseRepository.Common;
    using NBaseRepository.IntPrimary;

    public abstract class NBaseRepository<TEntity> : NBaseCoreRepository<TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="conversionFunc"></param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlConnection, sqlBuilder, conversionFunc)
        {
        }
    }
}
