// <copyright file="GuidSqlBuilder.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.GuidPrimary
{
    using System;
    using NBaseRepository.Common;

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
