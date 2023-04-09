namespace NBaseRepository.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class SqlBuilder<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        private readonly string _tableName;
        private string _sqlStatement;

        protected SqlBuilder(string tableName)
        {
            _tableName = tableName;
        }

        protected SqlBuilder()
        {
            _tableName = $"dbo.{typeof(TEntity).Name}";
        }

        public string SqlStatement
        {
            get
            {
                var toReturn = _sqlStatement;
                _sqlStatement = string.Empty;
                return toReturn;
            }
        }

        protected virtual Func<TEntity, IReadOnlyList<string>> EntityProperties { get; } = null;

        protected virtual string DefaultInclude => string.Empty;

        public SqlBuilder<TEntity, TId> SelectAll(bool withInclude = true)
        {
            _sqlStatement = $"SELECT * FROM {_tableName}";

            if (withInclude && DefaultInclude != string.Empty)
            {
                _sqlStatement += $" {DefaultInclude}";
            }

            return this;
        }

        public SqlBuilder<TEntity, TId> GetById(TId id, bool withInclude = true)
        {
            SelectAll(withInclude);

            _sqlStatement += $" WHERE Id == \'{id}\'";

            return this;
        }

        public SqlBuilder<TEntity, TId> Delete(TEntity entity)
        {
            _sqlStatement += $" DELETE FROM {_tableName} WHERE Id = '{entity.Id}' ";

            return this;
        }

        public SqlBuilder<TEntity, TId> DeleteById(TId id)
        {
            _sqlStatement += $" DELETE FROM {_tableName} WHERE Id = '{id}' ";

            return this;
        }

        public SqlBuilder<TEntity, TId> DeleteMultiple(IEnumerable<TEntity> entities)
        {
            _sqlStatement += $" DELETE FROM {_tableName} WHERE Id IN (${entities.Aggregate(string.Empty, (final, next) => final + $"{next.Id}, ").Trim().TrimEnd(',')})";

            return this;
        }

        public SqlBuilder<TEntity, TId> GetColumnNames()
        {
            var tableName = _tableName;

            if (_tableName.Contains("dbo."))
            {
                tableName = _tableName.Substring(4);
            }

            _sqlStatement += $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

            return this;
        }

        public SqlBuilder<TEntity, TId> Update(TEntity entity, IList<string> columnNames)
        {
            var entityProperties = EntityColumns(entity);

            var setStatement = string.Empty;

            for (var i = 0; i < columnNames.Count; i++)
            {
                setStatement += $"{columnNames[i]} = '{entityProperties[i]}', ";
            }

            setStatement = setStatement.Trim().Trim(',');

            _sqlStatement += $" UPDATE {_tableName} SET {setStatement} WHERE Id = '{entity.Id}'";

            return this;
        }

        public SqlBuilder<TEntity, TId> UpdateMultiple(IEnumerable<TEntity> entities, IEnumerable<string> columnNames)
        {
            return this;
        }

        public SqlBuilder<TEntity, TId> Insert(TEntity entity)
        {
            _sqlStatement += $" INSERT into {_tableName} VALUES ({EntityColumns(entity).Aggregate(string.Empty, (final, next) => final + $"'{next}', ").Trim().TrimEnd(',')})";

            return this;
        }

        public SqlBuilder<TEntity, TId> InsertMultiple(IEnumerable<TEntity> entities)
        {
            _sqlStatement += $" INSERT into {_tableName} VALUES" +
                      $" {entities.Aggregate(string.Empty, (final, next) => final + $"({InsertStatement(next)}), ")}";
            _sqlStatement = _sqlStatement.Trim().TrimEnd(',');

            return this;
        }

        private IList<string> EntityColumns(TEntity entity)
        {
            return EntityProperties == null ? typeof(TEntity).GetProperties().Select(property => property.GetValue(entity).ToString()).ToList() : EntityProperties.Invoke(entity).ToList();
        }

        private string InsertStatement(TEntity entity)
        {
            return EntityColumns(entity).Aggregate(string.Empty, (final, next) => final + $"'{next}', ").Trim().TrimEnd(',');
        }
    }
}
