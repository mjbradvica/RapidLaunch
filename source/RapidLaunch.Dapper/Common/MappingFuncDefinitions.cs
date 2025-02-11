// <copyright file="MappingFuncDefinitions.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
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
        /// Dapper mapping function for one object to an entity.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TEntity">The type of the entity being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired entity.</param>
        /// <returns>A func that will yield a <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, IEnumerable<TEntity>> FirstMappingFunc<TFirst, TEntity>(Func<TFirst, TEntity> mappingFunc)
        {
            return (connection, sql) => connection.Query<TFirst>(sql).Select(mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for one object to an entity asynchronously.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TEntity">The type of the entity being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired entity.</param>
        /// <returns>A func that will yield a <see cref="Task"/> of <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, Task<IEnumerable<TEntity>>> FirstMappingFuncAsync<TFirst, TEntity>(Func<TFirst, TEntity> mappingFunc)
        {
            return async (connection, sql) => (await connection.QueryAsync<TFirst>(sql)).Select(mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for two objects to an entity.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TEntity">The type of the entity being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired entity.</param>
        /// <returns>A func that will yield a <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, IEnumerable<TEntity>> SecondMappingFunc<TFirst, TSecond, TEntity>(Func<TFirst, TSecond, TEntity> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for two objects to an entity asynchronously.
        /// </summary>
        /// <typeparam name="TFirst">The type of the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TEntity">The type of the entity being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired entity.</param>
        /// <returns>A func that will yield a <see cref="Task"/> of <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, Task<IEnumerable<TEntity>>> SecondMappingFuncAsync<TFirst, TSecond, TEntity>(Func<TFirst, TSecond, TEntity> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for three objects to an entity.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TEntity">The type of the entity being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired entity.</param>
        /// <returns>A func that will yield a <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, IEnumerable<TEntity>> ThirdMappingFunc<TFirst, TSecond, TThird, TEntity>(Func<TFirst, TSecond, TThird, TEntity> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for three objects to an entity asynchronously.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TEntity">The type of the entity being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired entity.</param>
        /// <returns>A func that will yield a <see cref="Task"/> of <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, Task<IEnumerable<TEntity>>> ThirdMappingFuncAsync<TFirst, TSecond, TThird, TEntity>(Func<TFirst, TSecond, TThird, TEntity> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for four objects to an entity.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth mapped object.</typeparam>
        /// <typeparam name="TEntity">The type of the entity being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired entity.</param>
        /// <returns>A func that will yield a <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, IEnumerable<TEntity>> FourthMappingFunc<TFirst, TSecond, TThird, TFourth, TEntity>(Func<TFirst, TSecond, TThird, TFourth, TEntity> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for four objects to an entity asynchronously.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth mapped object.</typeparam>
        /// <typeparam name="TEntity">The type of the entity being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired entity.</param>
        /// <returns>A func that will yield a <see cref="Task"/> of <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, Task<IEnumerable<TEntity>>> FourthMappingFuncAsync<TFirst, TSecond, TThird, TFourth, TEntity>(Func<TFirst, TSecond, TThird, TFourth, TEntity> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for five objects to an entity.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth mapped object.</typeparam>
        /// <typeparam name="TFifth">The type of the fifth mapped object.</typeparam>
        /// <typeparam name="TEntity">The type of the entity being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired entity.</param>
        /// <returns>A func that will yield a <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, IEnumerable<TEntity>> FifthMappingFunc<TFirst, TSecond, TThird, TFourth, TFifth, TEntity>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for five objects to an entity asynchronously.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth mapped object.</typeparam>
        /// <typeparam name="TFifth">The type of the fifth mapped object.</typeparam>
        /// <typeparam name="TEntity">The type of the entity being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired entity.</param>
        /// <returns>A func that will yield a <see cref="Task"/> of <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, Task<IEnumerable<TEntity>>> FifthMappingFuncAsync<TFirst, TSecond, TThird, TFourth, TFifth, TEntity>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for six objects to an entity.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth mapped object.</typeparam>
        /// <typeparam name="TFifth">The type of the fifth mapped object.</typeparam>
        /// <typeparam name="TSixth">The type of the sixth mapped object.</typeparam>
        /// <typeparam name="TEntity">The type of the entity being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired entity.</param>
        /// <returns>A func that will yield a <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, IEnumerable<TEntity>> SixthMappingFunc<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for six objects to an entity asynchronously.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth mapped object.</typeparam>
        /// <typeparam name="TFifth">The type of the fifth mapped object.</typeparam>
        /// <typeparam name="TSixth">The type of the sixth mapped object.</typeparam>
        /// <typeparam name="TEntity">The type of the entity being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired entity.</param>
        /// <returns>A func that will yield a <see cref="Task"/> of <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, Task<IEnumerable<TEntity>>> SixthMappingFuncAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for seven objects to an entity.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth mapped object.</typeparam>
        /// <typeparam name="TFifth">The type of the fifth mapped object.</typeparam>
        /// <typeparam name="TSixth">The type of the sixth mapped object.</typeparam>
        /// <typeparam name="TSeventh">The type of the seventh mapped object.</typeparam>
        /// <typeparam name="TEntity">The type of the entity being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired entity.</param>
        /// <returns>A func that will yield a <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, IEnumerable<TEntity>> SeventhMappingFunc<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> mappingFunc)
        {
            return (connection, sql) => connection.Query(sql, mappingFunc);
        }

        /// <summary>
        /// Dapper mapping function for seven objects to an entity asynchronously.
        /// </summary>
        /// <typeparam name="TFirst">The type fo the first mapped object.</typeparam>
        /// <typeparam name="TSecond">The type of the second mapped object.</typeparam>
        /// <typeparam name="TThird">The type of the third mapped object.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth mapped object.</typeparam>
        /// <typeparam name="TFifth">The type of the fifth mapped object.</typeparam>
        /// <typeparam name="TSixth">The type of the sixth mapped object.</typeparam>
        /// <typeparam name="TSeventh">The type of the seventh mapped object.</typeparam>
        /// <typeparam name="TEntity">The type of the entity being created.</typeparam>
        /// <param name="mappingFunc">A mapping func to convert dapper objects to the desired entity.</param>
        /// <returns>A func that will yield a <see cref="Task"/> of <see cref="IEnumerable{T}"/>.</returns>
        public static Func<SqlConnection, string, Task<IEnumerable<TEntity>>> SeventhMappingFuncAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> mappingFunc)
        {
            return async (connection, sql) => await connection.QueryAsync(sql, mappingFunc);
        }
    }
}
