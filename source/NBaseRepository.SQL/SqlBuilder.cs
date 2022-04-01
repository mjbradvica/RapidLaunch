namespace NBaseRepository.SQL
{
    using System;
    using System.Collections.Generic;
    using Common;

    public abstract class SqlBuilder<T, TId>
        where T : IEntity<TId>
    {
        private readonly string _tableName;
        private string _query;

        protected SqlBuilder()
        {
            _tableName = $"ado.{typeof(T).Name}";
        }

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

        protected virtual string DefaultInclude { get; }

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
    }
}
