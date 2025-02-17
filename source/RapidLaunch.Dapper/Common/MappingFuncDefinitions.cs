// <copyright file="MappingFuncDefinitions.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Dapper;
using Microsoft.Data.SqlClient;

namespace RapidLaunch.Dapper.Common
{
    /// <summary>
    /// Mapping func definitions for dapper to reduce to a common interface.
    /// </summary>
    internal static class MappingFuncDefinitions
    {
        /// <summary>
        /// Dapper mapping function for one object to an root.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TRoot">The type of the root being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired root.</param>
        /// <returns>A func that will yield a <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, IEnumerable<TRoot>> FirstMappingFunc<TFirst, TRoot>(Func<TFirst, TRoot> mappingFunc)
        {
            return (connection, sql) => connection.Query<TFirst>(sql).Select(mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for one object to an root asynchronously.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TRoot">The type of the root being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired root.</param>
        /// <returns>A func that will yield a <see cref="Task"/> of <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, Task<IEnumerable<TRoot>>> FirstMappingFuncAsync<TFirst, TRoot>(Func<TFirst, TRoot> mappingFunc)
        {
            return async (connection, sql) => (await connection.QueryAsync<TFirst>(sql)).Select(mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for two objects to an root.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TRoot">The type of the root being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired root.</param>
        /// <returns>A func that will yield a <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, IEnumerable<TRoot>> SecondMappingFunc<TFirst, TSecond, TRoot>(Func<TFirst, TSecond, TRoot> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for two objects to an root asynchronously.
        /// </summary>
        /// <typeparam name="TFirst">The type of the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TRoot">The type of the root being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired root.</param>
        /// <returns>A func that will yield a <see cref="Task"/> of <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, Task<IEnumerable<TRoot>>> SecondMappingFuncAsync<TFirst, TSecond, TRoot>(Func<TFirst, TSecond, TRoot> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for three objects to an root.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TRoot">The type of the root being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired root.</param>
        /// <returns>A func that will yield a <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, IEnumerable<TRoot>> ThirdMappingFunc<TFirst, TSecond, TThird, TRoot>(Func<TFirst, TSecond, TThird, TRoot> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for three objects to an root asynchronously.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TRoot">The type of the root being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired root.</param>
        /// <returns>A func that will yield a <see cref="Task"/> of <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, Task<IEnumerable<TRoot>>> ThirdMappingFuncAsync<TFirst, TSecond, TThird, TRoot>(Func<TFirst, TSecond, TThird, TRoot> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for four objects to an root.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth mapped object.</typeparam>
        /// <typeparam name="TRoot">The type of the root being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired root.</param>
        /// <returns>A func that will yield a <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, IEnumerable<TRoot>> FourthMappingFunc<TFirst, TSecond, TThird, TFourth, TRoot>(Func<TFirst, TSecond, TThird, TFourth, TRoot> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for four objects to an root asynchronously.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth mapped object.</typeparam>
        /// <typeparam name="TRoot">The type of the root being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired root.</param>
        /// <returns>A func that will yield a <see cref="Task"/> of <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, Task<IEnumerable<TRoot>>> FourthMappingFuncAsync<TFirst, TSecond, TThird, TFourth, TRoot>(Func<TFirst, TSecond, TThird, TFourth, TRoot> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for five objects to an root.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth mapped object.</typeparam>
        /// <typeparam name="TFifth">The type of the fifth mapped object.</typeparam>
        /// <typeparam name="TRoot">The type of the root being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired root.</param>
        /// <returns>A func that will yield a <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, IEnumerable<TRoot>> FifthMappingFunc<TFirst, TSecond, TThird, TFourth, TFifth, TRoot>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TRoot> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for five objects to an root asynchronously.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth mapped object.</typeparam>
        /// <typeparam name="TFifth">The type of the fifth mapped object.</typeparam>
        /// <typeparam name="TRoot">The type of the root being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired root.</param>
        /// <returns>A func that will yield a <see cref="Task"/> of <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, Task<IEnumerable<TRoot>>> FifthMappingFuncAsync<TFirst, TSecond, TThird, TFourth, TFifth, TRoot>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TRoot> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for six objects to an root.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth mapped object.</typeparam>
        /// <typeparam name="TFifth">The type of the fifth mapped object.</typeparam>
        /// <typeparam name="TSixth">The type of the sixth mapped object.</typeparam>
        /// <typeparam name="TRoot">The type of the root being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired root.</param>
        /// <returns>A func that will yield a <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, IEnumerable<TRoot>> SixthMappingFunc<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TRoot>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TRoot> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for six objects to an root asynchronously.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth mapped object.</typeparam>
        /// <typeparam name="TFifth">The type of the fifth mapped object.</typeparam>
        /// <typeparam name="TSixth">The type of the sixth mapped object.</typeparam>
        /// <typeparam name="TRoot">The type of the root being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired root.</param>
        /// <returns>A func that will yield a <see cref="Task"/> of <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, Task<IEnumerable<TRoot>>> SixthMappingFuncAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TRoot>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TRoot> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for seven objects to an root.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth mapped object.</typeparam>
        /// <typeparam name="TFifth">The type of the fifth mapped object.</typeparam>
        /// <typeparam name="TSixth">The type of the sixth mapped object.</typeparam>
        /// <typeparam name="TSeventh">The type of the seventh mapped object.</typeparam>
        /// <typeparam name="TRoot">The type of the root being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired root.</param>
        /// <returns>A func that will yield a <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, IEnumerable<TRoot>> SeventhMappingFunc<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TRoot>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TRoot> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for seven objects to an root asynchronously.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth mapped object.</typeparam>
        /// <typeparam name="TFifth">The type of the fifth mapped object.</typeparam>
        /// <typeparam name="TSixth">The type of the sixth mapped object.</typeparam>
        /// <typeparam name="TSeventh">The type of the seventh mapped object.</typeparam>
        /// <typeparam name="TRoot">The type of the root being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired root.</param>
        /// <returns>A func that will yield a <see cref="Task"/> of <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, Task<IEnumerable<TRoot>>> SeventhMappingFuncAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TRoot>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TRoot> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }
    }
}
