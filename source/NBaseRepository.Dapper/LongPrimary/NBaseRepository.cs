﻿// <copyright file="NBaseRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Data.SqlClient;
using NBaseRepository.Dapper.Common;
using NBaseRepository.Common;
using NBaseRepository.LongPrimary;

namespace NBaseRepository.Dapper.LongPrimary
{
    public abstract class NBaseRepository<TFirst, TEntity> : NBaseCoreRepository<TFirst, TEntity, long>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="mappingFunc"></param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, long> sqlBuilder, Func<TFirst, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TEntity> : NBaseCoreRepository<TFirst, TSecond, TEntity, long>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="mappingFunc"></param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, long> sqlBuilder, Func<TFirst, TSecond, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TThird, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TEntity, long>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TThird, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="mappingFunc"></param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, long> sqlBuilder, Func<TFirst, TSecond, TThird, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TThird, TFourth, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TEntity, long>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TThird, TFourth, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="mappingFunc"></param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, long> sqlBuilder, Func<TFirst, TSecond, TThird, TFourth, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TEntity, long>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TThird, TFourth, TFifth, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="mappingFunc"></param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, long> sqlBuilder, Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity, long>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="mappingFunc"></param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, long> sqlBuilder, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity, long>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="mappingFunc"></param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, long> sqlBuilder, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }
}
