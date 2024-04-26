// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;
using MongoDB.Driver;
using RapidLaunch.Common;

namespace RapidLaunch.Mongo.Common
{
    /// <summary>
    /// Common functions for all Mongo RapidLaunch repositories.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public class RapidLaunchRepository<TEntity, TId> :
        IAddEntitiesAsync<TEntity, TId>,
        IGetAllEntities<TEntity, TId>,
        IGetAllEntitiesAsync<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        private readonly MongoClient _mongoClient;
        private readonly string _databaseName;
        private readonly string? _collectionName;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="mongoClient">An instance of the <see cref="MongoClient"/> class.</param>
        /// <param name="databaseName">The name of the database to use.</param>
        /// <param name="collectionName">Optional collection name.</param>
        public RapidLaunchRepository(MongoClient mongoClient, string databaseName, string? collectionName = null)
        {
            _mongoClient = mongoClient;
            _databaseName = databaseName;
            _collectionName = collectionName;
        }

        /// <inheritdoc />
        public virtual async Task<RapidLaunchStatus> AddEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
            {
                var aggregateRoots = entities.ToList();

                await GetCollection().InsertManyAsync(aggregateRoots, null, cancellationToken);

                return (aggregateRoots.Count, aggregateRoots);
            },
                cancellationToken);
        }

        /// <summary>
        /// Adds multiple entities to a collection.
        /// </summary>
        /// <param name="entities">A <see cref="IEnumerable{TEntity}"/> to be added.</param>
        /// <param name="options">An instance of the <see cref="InsertManyOptions"/> class.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="RapidLaunchStatus"/> that represents the asynchronous operation.</returns>
        public virtual async Task<RapidLaunchStatus> AddEntitiesAsync(IEnumerable<TEntity> entities, InsertManyOptions options, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async () =>
                {
                    var aggregateRoots = entities.ToList();

                    await GetCollection().InsertManyAsync(aggregateRoots, options, cancellationToken);

                    return (aggregateRoots.Count, aggregateRoots);
                },
                cancellationToken);
        }

        /// <inheritdoc/>
        public List<TEntity> GetAllEntities()
        {
            return ExecuteQuery(() =>
            {
                var filter = Builders<TEntity>.Filter.Empty;

                return GetCollection().Find(filter).ToCursor();
            });
        }

        /// <summary>
        /// Retrieves all entities of type from a collection.
        /// </summary>
        /// <param name="options">An instance of the <see cref="FindOptions"/> class.</param>
        /// <returns>An of <see cref="List{TEntity}"/>.</returns>
        public List<TEntity> GetAllEntities(FindOptions options)
        {
            return ExecuteQuery(() =>
            {
                var filter = Builders<TEntity>.Filter.Empty;

                return GetCollection().Find(filter, options).ToCursor();
            });
        }

        /// <inheritdoc/>
        public virtual async Task<List<TEntity>> GetAllEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(
                async () =>
            {
                var filter = Builders<TEntity>.Filter.Empty;

                return await GetCollection().FindAsync(filter, cancellationToken: cancellationToken);
            },
                cancellationToken);
        }

        /// <summary>
        /// Executes a command against the persistence.
        /// </summary>
        /// <param name="executionFunc">A <see cref="Func{TResult}"/> that contains an operation to execute.</param>
        /// <param name="postOperationFunc">A <see cref="Func{TResult}"/> to run post operation effects.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> indicating the status of the operation.</returns>
        protected virtual RapidLaunchStatus ExecuteCommand(Func<(int RowCount, IEnumerable<TEntity> Entities)> executionFunc, Func<int, IEnumerable<IAggregateRoot<TId>>, Task>? postOperationFunc = default)
        {
            int rowsAffected;

            using (var transaction = _mongoClient.StartSession())
            {
                try
                {
                    var (rowCount, aggregateRoots) = executionFunc.Invoke();

                    rowsAffected = rowCount;

                    if (postOperationFunc != null)
                    {
                        postOperationFunc.Invoke(rowsAffected, aggregateRoots).RunSynchronously();
                    }

                    transaction.CommitTransaction();
                }
                catch (Exception exception)
                {
                    transaction.AbortTransaction();

                    return RapidLaunchStatus.Failed(exception);
                }
            }

            return RapidLaunchStatus.Success(rowsAffected);
        }

        /// <summary>
        /// Executes a command against the persistence.
        /// </summary>
        /// <param name="executionFunc">A <see cref="Func{TResult}"/> that contains an operation to execute.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <param name="postOperationFunc">A <see cref="Func{TResult}"/> to run post operation effects.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected virtual async Task<RapidLaunchStatus> ExecuteCommandAsync(Func<Task<(int RowCount, IEnumerable<TEntity> Entities)>> executionFunc, CancellationToken cancellationToken, Func<int, IEnumerable<IAggregateRoot<TId>>, Task>? postOperationFunc = default)
        {
            int rowsAffected;

            using (var transaction = await _mongoClient.StartSessionAsync(cancellationToken: cancellationToken))
            {
                try
                {
                    var (rowCount, aggregateRoots) = await executionFunc.Invoke();

                    rowsAffected = rowCount;

                    if (postOperationFunc != null)
                    {
                        await postOperationFunc.Invoke(rowsAffected, aggregateRoots);
                    }

                    await transaction.CommitTransactionAsync(cancellationToken);
                }
                catch (Exception exception)
                {
                    await transaction.AbortTransactionAsync(cancellationToken);

                    return RapidLaunchStatus.Failed(exception);
                }
            }

            return RapidLaunchStatus.Success(rowsAffected);
        }

        /// <summary>
        /// Executes a query against the persistence.
        /// </summary>
        /// <param name="query">A <see cref="Func{TResult}"/> that executes a Mongo operation.</param>
        /// <returns>A <see cref="List{T}"/> of entities.</returns>
        protected virtual List<TEntity> ExecuteQuery(Func<IAsyncCursor<TEntity>> query)
        {
            var cursor = query.Invoke();

            var results = new List<TEntity>();

            if (cursor.MoveNext())
            {
                results.AddRange(cursor.Current);
            }

            return results;
        }

        /// <summary>
        /// Executes a query against the persistence.
        /// </summary>
        /// <param name="query">A <see cref="Func{TResult}"/> that executes a Mongo operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="List{T}"/> representing the asynchronous operation.</returns>
        protected virtual async Task<List<TEntity>> ExecuteQueryAsync(Func<Task<IAsyncCursor<TEntity>>> query, CancellationToken cancellationToken)
        {
            var cursor = await query.Invoke();

            var results = new List<TEntity>();

            if (await cursor.MoveNextAsync(cancellationToken))
            {
                results.AddRange(cursor.Current);
            }

            return results;
        }

        private IMongoCollection<TEntity> GetCollection()
        {
            return _mongoClient.GetDatabase(_databaseName).GetCollection<TEntity>(_collectionName ?? typeof(TEntity).Name);
        }
    }
}
