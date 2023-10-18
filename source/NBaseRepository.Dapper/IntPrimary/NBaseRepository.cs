// <copyright file="NBaseRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Dapper.IntPrimary
{
    using System;
    using System.Data.SqlClient;
    using NBaseRepository.Dapper.Common;
    using NBaseRepository.Common;
    using NBaseRepository.IntPrimary;

    public abstract class NBaseRepository<TFirst, TEntity> : NBaseCoreRepository<TFirst, TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="mappingFunc"></param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<TFirst, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TEntity> : NBaseCoreRepository<TFirst, TSecond, TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="mappingFunc"></param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<TFirst, TSecond, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TThird, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TThird, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="mappingFunc"></param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<TFirst, TSecond, TThird, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TThird, TFourth, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TThird, TFourth, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="mappingFunc"></param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<TFirst, TSecond, TThird, TFourth, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TThird, TFourth, TFifth, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="mappingFunc"></param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="mappingFunc"></param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }

    public abstract class NBaseRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> : NBaseCoreRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        /// <param name="mappingFunc"></param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> mappingFunc)
            : base(sqlConnection, sqlBuilder, mappingFunc)
        {
        }
    }
}
