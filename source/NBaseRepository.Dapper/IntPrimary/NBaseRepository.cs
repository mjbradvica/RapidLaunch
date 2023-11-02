// <copyright file="NBaseRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Data.SqlClient;
using NBaseRepository.Common;
using NBaseRepository.Dapper.Common;
using NBaseRepository.IntPrimary;

namespace NBaseRepository.Dapper.IntPrimary
{
    /// <summary>
    /// A base class for dapper repositories of type <see cref="int"/>.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped class.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class NBaseRepository<TFirst, TEntity> : NBaseCoreRepository<TFirst, TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping func from the returned classes to an entity.</param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<TFirst, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    /// <summary>
    /// A base class for dapper repositories of type <see cref="int"/>.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped class.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped class.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class NBaseRepository<TFirst, TSecond, TEntity> : NBaseCoreRepository<TFirst, TSecond, TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping func from the returned classes to an entity.</param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<TFirst, TSecond, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    /// <summary>
    /// A base class for dapper repositories of type <see cref="int"/>.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped class.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped class.</typeparam>
    /// <typeparam name="TThird">The type of the third mapped class.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class NBaseRepository<TFirst, TSecond, TThird, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TThird, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping func from the returned classes to an entity.</param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<TFirst, TSecond, TThird, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    /// <summary>
    /// A base class for dapper repositories of type <see cref="int"/>.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped class.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped class.</typeparam>
    /// <typeparam name="TThird">The type of the third mapped class.</typeparam>
    /// <typeparam name="TFourth">The type of the fourth mapped class.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class NBaseRepository<TFirst, TSecond, TThird, TFourth, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TThird, TFourth, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping func from the returned classes to an entity.</param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<TFirst, TSecond, TThird, TFourth, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    /// <summary>
    /// A base class for dapper repositories of type <see cref="int"/>.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped class.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped class.</typeparam>
    /// <typeparam name="TThird">The type of the third mapped class.</typeparam>
    /// <typeparam name="TFourth">The type of the fourth mapped class.</typeparam>
    /// <typeparam name="TFifth">The type of the fifth mapped class.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class NBaseRepository<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TThird, TFourth, TFifth, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping func from the returned classes to an entity.</param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    /// <summary>
    /// A base class for dapper repositories of type <see cref="int"/>.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped class.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped class.</typeparam>
    /// <typeparam name="TThird">The type of the third mapped class.</typeparam>
    /// <typeparam name="TFourth">The type of the fourth mapped class.</typeparam>
    /// <typeparam name="TFifth">The type of the fifth mapped class.</typeparam>
    /// <typeparam name="TSixth">The type of the sixth mapped class.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class NBaseRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping func from the returned classes to an entity.</param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    /// <summary>
    /// A base class for dapper repositories of type <see cref="int"/>.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped class.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped class.</typeparam>
    /// <typeparam name="TThird">The type of the third mapped class.</typeparam>
    /// <typeparam name="TFourth">The type of the fourth mapped class.</typeparam>
    /// <typeparam name="TFifth">The type of the fifth mapped class.</typeparam>
    /// <typeparam name="TSixth">The type of the sixth mapped class.</typeparam>
    /// <typeparam name="TSeventh">The type of the seventh mapped class.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class NBaseRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping func from the returned classes to an entity.</param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }
}
