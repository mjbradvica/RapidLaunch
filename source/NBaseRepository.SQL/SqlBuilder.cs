namespace NBaseRepository.SQL
{
    using System;
    using System.Collections.Generic;
    using Common;

    public abstract class SqlBuilder<T, TId>
        where T : IEntity<TId>
    {
        private readonly string _tableName;
        private readonly IEnumerable<string> _columns;
        private string _query;

        protected SqlBuilder(string tableName, params string[] columns)
        {
            _tableName = tableName;
            _columns = columns;
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

        protected Func<T, IReadOnlyList<string>> EntityProperties { get; }

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
