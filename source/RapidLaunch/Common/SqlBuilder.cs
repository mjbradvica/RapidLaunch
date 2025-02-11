﻿// <copyright file="SqlBuilder.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// SQL Builder for basic queries and commands.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public abstract class SqlBuilder<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        private readonly string _tableName;
        private string _sqlStatement;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlBuilder{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="tableName">The name of the tableName if different from the default.</param>
        protected SqlBuilder(string tableName)
        {
            _tableName = tableName;
            _sqlStatement = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlBuilder{TEntity, TId}"/> class.
        /// </summary>
        protected SqlBuilder()
        {
            _tableName = $"dbo.{typeof(TEntity).Name}";
            _sqlStatement = string.Empty;
        }

        /// <summary>
        /// Gets the final sql statement to perform an operation.
        /// </summary>
        public string SqlStatement
        {
            get
            {
                var toReturn = _sqlStatement;
                _sqlStatement = string.Empty;
                return toReturn;
            }
        }

        /// <summary>
        /// Gets the column names for an entities table.
        /// </summary>
        public IEnumerable<string>? ColumnNames { get; private set; }

        /// <summary>
        /// Gets a function that extracts the current values from the entity for inserts.
        /// </summary>
        protected abstract Func<TEntity, List<object>> EntityProperties { get; }

        /// <summary>
        /// Gets the include statement if any to load additional relationships.
        /// </summary>
        protected virtual string DefaultInclude => string.Empty;

        /// <summary>
        /// Updates the column names for a table if they do not exist.
        /// </summary>
        /// <param name="columnNames">A list of column names to use for updates.</param>
        public void UpdateColumnNames(IEnumerable<string> columnNames)
        {
            // Business logic to check against errant column count.
            ColumnNames = columnNames;
        }

        /// <summary>
        /// Returns a builder with a select all statement.
        /// </summary>
        /// <param name="withInclude">Flag to indicate if additional relationships should be loaded.</param>
        /// <returns>The <see cref="SqlBuilder{TEntity,TId}"/> instance with an updated sql statement.</returns>
        public SqlBuilder<TEntity, TId> SelectAll(bool withInclude = true)
        {
            _sqlStatement = $"SELECT * FROM {_tableName}";

            if (withInclude && DefaultInclude != string.Empty)
            {
                _sqlStatement += $" {DefaultInclude}";
            }

            return this;
        }

        /// <summary>
        /// Returns a builder with a get by id statement.
        /// </summary>
        /// <param name="id">The identifier for the entity.</param>
        /// <param name="withInclude">Flag to indicate if additional relationships should be loaded.</param>
        /// <returns>The <see cref="SqlBuilder{TEntity,TId}"/> instance with an updated sql statement.</returns>
        public SqlBuilder<TEntity, TId> GetById(TId id, bool withInclude = true)
        {
            SelectAll(withInclude);

            _sqlStatement += $" WHERE {_tableName}.Id = \'{id}\'";

            return this;
        }

        /// <summary>
        /// Returns a builder with a delete statement.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        /// <returns>The <see cref="SqlBuilder{TEntity,TId}"/> instance with an updated sql statement.</returns>
        public SqlBuilder<TEntity, TId> Delete(TEntity entity)
        {
            _sqlStatement += $" DELETE FROM {_tableName} WHERE Id = '{entity.Id}' ";

            return this;
        }

        /// <summary>
        /// Returns a builder with a delete multiple entities statements.
        /// </summary>
        /// <param name="entities">A list of entities to be removed.</param>
        /// <returns>The <see cref="SqlBuilder{TEntity,TId}"/> instance with an updated sql statement.</returns>
        public SqlBuilder<TEntity, TId> DeleteMultiple(IEnumerable<TEntity> entities)
        {
            _sqlStatement += $" DELETE FROM {_tableName} WHERE Id IN (${entities.Aggregate(string.Empty, (final, next) => final + $"{next.Id}, ").Trim().TrimEnd(',')})";

            return this;
        }

        /// <summary>
        /// Returns a builder with a get column names statement.
        /// </summary>
        /// <returns>The <see cref="SqlBuilder{TEntity,TId}"/> instance with an updated sql statement.</returns>
        public SqlBuilder<TEntity, TId> GetColumnNames()
        {
            var tableName = _tableName;

            if (_tableName.Contains("dbo."))
            {
                tableName = tableName.Replace("dbo.", string.Empty);
            }

            _sqlStatement += $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

            return this;
        }

        /// <summary>
        /// Returns a builder with an update statement.
        /// </summary>
        /// <param name="entity">The entity being updated in persistence.</param>
        /// <param name="columnNames">The names of the columns used for the entity.</param>
        /// <returns>The <see cref="SqlBuilder{TEntity,TId}"/> instance with an updated sql statement.</returns>
        public SqlBuilder<TEntity, TId> Update(TEntity entity, IList<string> columnNames)
        {
            var entityProperties = EntityProperties(entity);

            var setStatement = string.Empty;

            for (var i = 0; i < columnNames.Count; i++)
            {
                setStatement += $"{columnNames[i]} = '{entityProperties[i]}', ";
            }

            setStatement = setStatement.Trim().Trim(',');

            _sqlStatement += $" UPDATE {_tableName} SET {setStatement} WHERE Id = '{entity.Id}'";

            return this;
        }

        /// <summary>
        /// Returns a builder with an update multiple statement.
        /// </summary>
        /// <param name="entities">The entities being updated in persistence.</param>
        /// <param name="columnNames">The names of the columns used for the entity.</param>
        /// <returns>The <see cref="SqlBuilder{TEntity,TId}"/> instance with an updated sql statement.</returns>
        public SqlBuilder<TEntity, TId> UpdateMultiple(IEnumerable<TEntity> entities, IEnumerable<string> columnNames)
        {
            return this;
        }

        /// <summary>
        /// Returns a builder with an insert statement.
        /// </summary>
        /// <param name="entity">The entity being inserted in persistence.</param>
        /// <returns>The <see cref="SqlBuilder{TEntity,TId}"/> instance with an updated sql statement.</returns>
        public SqlBuilder<TEntity, TId> Insert(TEntity entity)
        {
            _sqlStatement += $" INSERT into {_tableName} VALUES ({InsertStatement(entity)})";

            return this;
        }

        /// <summary>
        /// Returns a builder with an insert multiple statement.
        /// </summary>
        /// <param name="entities">A collection of entities to be updated.</param>
        /// <returns>The <see cref="SqlBuilder{TEntity,TId}"/> instance with an updated sql statement.</returns>
        public SqlBuilder<TEntity, TId> InsertMultiple(IEnumerable<TEntity> entities)
        {
            _sqlStatement += $" INSERT into {_tableName} VALUES" +
                      $" {entities.Aggregate(string.Empty, (final, next) => final + $"({InsertStatement(next)}), ")}";
            _sqlStatement = _sqlStatement.Trim().TrimEnd(',');

            return this;
        }

        private string InsertStatement(TEntity entity)
        {
            return EntityProperties(entity).Aggregate(string.Empty, (final, next) => final + $"'{next}', ").Trim().TrimEnd(',');
        }
    }
}
