// <copyright file="LongSqlBuilder.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Common;

namespace NBaseRepository.LongPrimary
{
    public abstract class LongSqlBuilder<TEntity> : SqlBuilder<TEntity, long>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LongSqlBuilder{TEntity}"/> class.
        /// </summary>
        protected LongSqlBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LongSqlBuilder{TEntity}"/> class.
        /// </summary>
        /// <param name="tableName"></param>
        protected LongSqlBuilder(string tableName)
        : base(tableName)
        {
        }
    }
}
