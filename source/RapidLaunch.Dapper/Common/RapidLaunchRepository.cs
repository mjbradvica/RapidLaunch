// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using Dapper;
using Microsoft.Data.SqlClient;
using RapidLaunch.Common;

namespace RapidLaunch.Dapper.Common
{
    /// <summary>
    /// Common functions for all base RapidLaunch repositories.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public abstract class RapidLaunchRepository<TEntity, TId> :
        IGetAllEntitiesAsync<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        private readonly Func<SqlConnection, string, IEnumerable<TEntity>> _executionFunc;
        private readonly Func<SqlConnection, string, Task<IEnumerable<TEntity>>> _asyncExecutionFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="connection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity, TId}"/> class.</param>
        /// <param name="executionFunc">The synchronous execution func.</param>
        /// <param name="asyncExecutionFunc">The asynchronous execution func.</param>
        protected RapidLaunchRepository(
            SqlConnection connection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<SqlConnection, string, IEnumerable<TEntity>> executionFunc,
            Func<SqlConnection, string, Task<IEnumerable<TEntity>>> asyncExecutionFunc)
        {
            Connection = connection;
            SqlBuilder = sqlBuilder;
            _executionFunc = executionFunc;
            _asyncExecutionFunc = asyncExecutionFunc;
        }

        /// <summary>
        /// Gets the <see cref="SqlConnection"/> instance.
        /// </summary>
        protected SqlConnection Connection { get; }

        /// <summary>
        /// Gets the <see cref="SqlBuilder"/> instance.
        /// </summary>
        protected SqlBuilder<TEntity, TId> SqlBuilder { get; }

        /// <inheritdoc/>
        public virtual async Task<List<TEntity>> GetAllEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(string.Empty, cancellationToken);
        }

        /// <summary>
        /// Executes a query against the persistence.
        /// </summary>
        /// <param name="sql">The <see cref="string"/> sql to be executed.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="List{T}"/> representing the asynchronous operation.</returns>
        protected virtual async Task<List<TEntity>> ExecuteQueryAsync(string sql, CancellationToken cancellationToken)
        {
            await Connection.OpenAsync(cancellationToken);

            var entities = await Connection.QueryAsync<TEntity>(sql);

            await Connection.CloseAsync();

            return entities.ToList();
        }
    }

    /// <summary>
    /// Base core Repository for Dapper that uses one return object.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped object from dapper.</typeparam>
    /// <typeparam name="TEntity">The type of the entity for operations.</typeparam>
    /// <typeparam name="TId">The type of the entities' identifier.</typeparam>
    public abstract class RapidLaunchRepository<TFirst, TEntity, TId> : RapidLaunchRepository<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TFirst, TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping function that converts a series of objects into an entity.</param>
        protected RapidLaunchRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                MappingFuncDefinitions.FirstMappingFunc(mappingFunc),
                MappingFuncDefinitions.FirstMappingFuncAsync(mappingFunc))
        {
        }
    }

    /// <summary>
    /// Base core Repository for Dapper that uses two return objects.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped object from dapper.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped object from dapper.</typeparam>
    /// <typeparam name="TEntity">The type of the entity for operations.</typeparam>
    /// <typeparam name="TId">The type of the entities' identifier.</typeparam>
    public abstract class RapidLaunchRepository<TFirst, TSecond, TEntity, TId> : RapidLaunchRepository<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TFirst, TSecond, TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping function that converts a series of objects into an entity.</param>
        protected RapidLaunchRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                MappingFuncDefinitions.SecondMappingFunc(mappingFunc),
                MappingFuncDefinitions.SecondMappingFuncAsync(mappingFunc))
        {
        }
    }

    /// <summary>
    /// Base core Repository for Dapper that uses three return objects.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped object from dapper.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped object from dapper.</typeparam>
    /// <typeparam name="TThird">The type of the third mapped object from dapper.</typeparam>
    /// <typeparam name="TEntity">The type of the entity for operations.</typeparam>
    /// <typeparam name="TId">The type of the entities' identifier.</typeparam>
    public abstract class RapidLaunchRepository<TFirst, TSecond, TThird, TEntity, TId> : RapidLaunchRepository<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TFirst, TSecond, TThird, TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping function that converts a series of objects into the desired entity.</param>
        protected RapidLaunchRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TThird, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                MappingFuncDefinitions.ThirdMappingFunc(mappingFunc),
                MappingFuncDefinitions.ThirdMappingFuncAsync(mappingFunc))
        {
        }
    }

    /// <summary>
    /// Base core Repository for Dapper that uses four return objects.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped object from dapper.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped object from dapper.</typeparam>
    /// <typeparam name="TThird">The type of the third mapped object from dapper.</typeparam>
    /// <typeparam name="TFourth">The type of the fourth mapped object from dapper.</typeparam>
    /// <typeparam name="TEntity">The type of the entity for operations.</typeparam>
    /// <typeparam name="TId">The type of the entities' identifier.</typeparam>
    public abstract class RapidLaunchRepository<TFirst, TSecond, TThird, TFourth, TEntity, TId> : RapidLaunchRepository<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TFirst, TSecond, TThird, TFourth, TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping function that converts a series of objects into an entity.</param>
        protected RapidLaunchRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TThird, TFourth, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                MappingFuncDefinitions.FourthMappingFunc(mappingFunc),
                MappingFuncDefinitions.FourthMappingFuncAsync(mappingFunc))
        {
        }
    }

    /// <summary>
    /// Base core Repository for Dapper that uses five return objects.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped object from dapper.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped object from dapper.</typeparam>
    /// <typeparam name="TThird">The type of the third mapped object from dapper.</typeparam>
    /// <typeparam name="TFourth">The type of the fourth mapped object from dapper.</typeparam>
    /// <typeparam name="TFifth">The type of the fifth mapped object from dapper.</typeparam>
    /// <typeparam name="TEntity">The type of the entity for operations.</typeparam>
    /// <typeparam name="TId">The type of the entities' identifier.</typeparam>
    public abstract class RapidLaunchRepository<TFirst, TSecond, TThird, TFourth, TFifth, TEntity, TId> : RapidLaunchRepository<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TFirst, TSecond, TThird, TFourth, TFifth, TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping function that converts a series of objects into an entity.</param>
        protected RapidLaunchRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                MappingFuncDefinitions.FifthMappingFunc(mappingFunc),
                MappingFuncDefinitions.FifthMappingFuncAsync(mappingFunc))
        {
        }
    }

    /// <summary>
    /// Base core Repository for Dapper that uses six return objects.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped object from dapper.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped object from dapper.</typeparam>
    /// <typeparam name="TThird">The type of the third mapped object from dapper.</typeparam>
    /// <typeparam name="TFourth">The type of the fourth mapped object from dapper.</typeparam>
    /// <typeparam name="TFifth">The type of the fifth mapped object from dapper.</typeparam>
    /// <typeparam name="TSixth">The type of the sixth mapped object from dapper.</typeparam>
    /// <typeparam name="TEntity">The type of the entity for operations.</typeparam>
    /// <typeparam name="TId">The type of the entities' identifier.</typeparam>
    public abstract class RapidLaunchRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity, TId> : RapidLaunchRepository<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping function that converts a series of objects into an entity.</param>
        protected RapidLaunchRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                MappingFuncDefinitions.SixthMappingFunc(mappingFunc),
                MappingFuncDefinitions.SixthMappingFuncAsync(mappingFunc))
        {
        }
    }

    /// <summary>
    /// Base core Repository for Dapper that uses seven return objects.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first mapped object from dapper.</typeparam>
    /// <typeparam name="TSecond">The type of the second mapped object from dapper.</typeparam>
    /// <typeparam name="TThird">The type of the third mapped object from dapper.</typeparam>
    /// <typeparam name="TFourth">The type of the fourth mapped object from dapper.</typeparam>
    /// <typeparam name="TFifth">The type of the fifth mapped object from dapper.</typeparam>
    /// <typeparam name="TSixth">The type of the sixth mapped object from dapper.</typeparam>
    /// <typeparam name="TSeventh">The type of the seventh mapped object from dapper.</typeparam>
    /// <typeparam name="TEntity">The type of the entity for operations.</typeparam>
    /// <typeparam name="TId">The type of the entities' identifier.</typeparam>
    public abstract class RapidLaunchRepository<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity, TId> : RapidLaunchRepository<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="mappingFunc">A mapping function that converts a series of objects into an entity.</param>
        protected RapidLaunchRepository(
            SqlConnection sqlConnection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEntity> mappingFunc)
            : base(
                sqlConnection,
                sqlBuilder,
                MappingFuncDefinitions.SeventhMappingFunc(mappingFunc),
                MappingFuncDefinitions.SeventhMappingFuncAsync(mappingFunc))
        {
        }
    }
}
