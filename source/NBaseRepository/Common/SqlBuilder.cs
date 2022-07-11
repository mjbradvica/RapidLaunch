using System;
using System.Collections.Generic;
using System.Linq;

namespace NBaseRepository.Common
{
    public abstract class SqlBuilder<T, TId>
        where T : IEntity<TId>
        where TId : struct
    {
        private readonly string _tableName;
        private string _query;

        protected SqlBuilder(string tableName)
        {
            _tableName = tableName;
        }

        public string Query
        {
            get
            {
                var toReturn = _query;
                _query = string.Empty;
                return toReturn;
            }
        }

        protected abstract Func<T, IReadOnlyList<string>> EntityProperties { get; }

        public SqlBuilder<T, TId> SelectAll()
        {
            _query = $"SELECT * FROM {_tableName}";

            return this;
        }

        public SqlBuilder<T, TId> GetById(TId id)
        {
            _query += $" WHERE Id == \'{id}\'";

            return this;
        }

        public SqlBuilder<T, TId> InsertMultiple(IEnumerable<T> entities)
        {
            _query += $" INSERT into {_tableName} VALUES" +
                      $" {entities.Aggregate(string.Empty, (final, next) => final + $"({InsertStatement(next)}), ")}";
            _query = _query.Trim().TrimEnd(',');

            return this;
        }

        private string InsertStatement(T entity)
        {
            return EntityProperties.Invoke(entity).Aggregate(string.Empty, (final, next) => final + $"'{next}', ").Trim().TrimEnd(',');
        }
    }
}
