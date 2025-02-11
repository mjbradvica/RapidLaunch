// <copyright file="SqlBuilder.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public abstract class SqlBuilder<TEntity> : SqlBuilder<TEntity, string>
        where TEntity : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected SqlBuilder(string tableName)
            : base(tableName)
        {
        }

        /// <inheritdoc />
        protected SqlBuilder()
        {
        }
    }
}
