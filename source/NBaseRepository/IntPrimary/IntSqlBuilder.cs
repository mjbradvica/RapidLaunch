// <copyright file="IntSqlBuilder.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.IntPrimary
{
    using NBaseRepository.Common;

    public abstract class IntSqlBuilder<TEntity> : SqlBuilder<TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntSqlBuilder{TEntity}"/> class.
        /// </summary>
        protected IntSqlBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntSqlBuilder{TEntity}"/> class.
        /// </summary>
        /// <param name="tableName"></param>
        protected IntSqlBuilder(string tableName)
            : base(tableName)
        {
        }
    }
}
