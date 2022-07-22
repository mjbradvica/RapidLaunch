namespace NBaseRepository.Dapper.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using global::Dapper;

    internal static class MappingFuncDefinitions
    {
        public static Func<SqlConnection, string, IEnumerable<TEntity>> FirstMappingFunc<TFirst, TEntity>(Func<TFirst, TEntity> mappingFunc)
        {
            return (connection, sql) => connection.Query<TFirst>(sql).Select(mappingFunc);
        }

        public static Func<SqlConnection, string, Task<IEnumerable<TEntity>>> FirstMappingFuncAsync<TFirst, TEntity>(Func<TFirst, TEntity> mappingFunc)
        {
            return async (connection, sql) => (await connection.QueryAsync<TFirst>(sql)).Select(mappingFunc);
        }

        public static Func<SqlConnection, string, IEnumerable<TEntity>> SecondMappingFunc<TFirst, TSecond, TEntity>(Func<TFirst, TSecond, TEntity> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        public static Func<SqlConnection, string, Task<IEnumerable<TEntity>>> SecondMappingFuncAsync<TFirst, TSecond, TEntity>(Func<TFirst, TSecond, TEntity> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }
    }
}
