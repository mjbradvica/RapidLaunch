// <copyright file="LongSqlBuilder.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.LongPrimary
{
    using NBaseRepository.Common;

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
