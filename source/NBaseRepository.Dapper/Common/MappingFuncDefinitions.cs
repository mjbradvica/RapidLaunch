// <copyright file="MappingFuncDefinitions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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

        public static Func<SqlConnection, string, IEnumerable<TEntity>> ThirdMappingFunc<TFirst, TSecond, TThird, TEntity>(Func<TFirst, TSecond, TThird, TEntity> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        public static Func<SqlConnection, string, Task<IEnumerable<TEntity>>> ThirdMappingFuncAsync<TFirst, TSecond, TThird, TEntity>(Func<TFirst, TSecond, TThird, TEntity> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }

        public static Func<SqlConnection, string, IEnumerable<TEntity>> FourthMappingFunc<TFirst, TSecond, TThird, TFourth, TEntity>(Func<TFirst, TSecond, TThird, TFourth, TEntity> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        public static Func<SqlConnection, string, Task<IEnumerable<TEntity>>> FourthMappingFuncAsync<TFirst, TSecond, TThird, TFourth, TEntity>(Func<TFirst, TSecond, TThird, TFourth, TEntity> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }

        public static Func<SqlConnection, string, IEnumerable<TEntity>> FifthMappingFunc<TFirst, TSecond, TThird, TFourth, TFifth, TEntity>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        public static Func<SqlConnection, string, Task<IEnumerable<TEntity>>> FifthMappingFuncAsync<TFirst, TSecond, TThird, TFourth, TFifth, TEntity>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }

        public static Func<SqlConnection, string, IEnumerable<TEntity>> SixthMappingFunc<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        public static Func<SqlConnection, string, Task<IEnumerable<TEntity>>> SixthMappingFuncAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }

        public static Func<SqlConnection, string, IEnumerable<TEntity>> SeventhMappingFunc<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        public static Func<SqlConnection, string, Task<IEnumerable<TEntity>>> SeventhMappingFuncAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }
    }
}
