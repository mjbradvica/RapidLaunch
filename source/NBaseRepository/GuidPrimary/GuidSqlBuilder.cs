// <copyright file="GuidSqlBuilder.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using NBaseRepository.Common;

namespace NBaseRepository.GuidPrimary
{
    public abstract class GuidSqlBuilder<TEntity> : SqlBuilder<TEntity, Guid>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidSqlBuilder{TEntity}"/> class.
        /// </summary>
        protected GuidSqlBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuidSqlBuilder{TEntity}"/> class.
        /// </summary>
        /// <param name="tableName"></param>
        protected GuidSqlBuilder(string tableName)
            : base(tableName)
        {
        }
    }
}
