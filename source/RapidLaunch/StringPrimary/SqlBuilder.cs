// <copyright file="SqlBuilder.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public class SqlBuilder<TEntity> : SqlBuilder<TEntity, string>
        where TEntity : class, IAggregateRoot
    {
        /// <inheritdoc />
        public SqlBuilder(string tableName)
            : base(tableName)
        {
        }

        /// <inheritdoc />
        public SqlBuilder()
        {
        }
    }
}
