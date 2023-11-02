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
    /// <summary>
    /// A base repository for <see cref="Guid"/> based entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class NBaseRepository<TEntity> : NBaseCoreRepository<TEntity, Guid>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">A instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="conversionFunc">A conversion func to read from a <see cref="SqlDataReader"/> result set.</param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, Guid> sqlBuilder, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlConnection, sqlBuilder, conversionFunc)
        {
        }
    }
}
