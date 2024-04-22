// <copyright file="RapidLaunchRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
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
            var aggregateRoots = entities.ToList();

            try
            {
                await GetCollection().InsertManyAsync(aggregateRoots, null, cancellationToken);
            }
            catch (Exception exception)
            {
                return RapidLaunchStatus.Failed(exception);
            }

            return RapidLaunchStatus.Success(aggregateRoots.Count);
        }

        /// <inheritdoc/>
        public virtual async Task<List<TEntity>> GetAllEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var filter = Builders<TEntity>.Filter.Empty;

            var cursor = await GetCollection().FindAsync(filter, cancellationToken: cancellationToken);

            IEnumerable<TEntity> results = new List<TEntity>();

            if (await cursor.MoveNextAsync(cancellationToken))
            {
                results = cursor.Current;
            }

            return results.ToList();
        }

        private IMongoCollection<TEntity> GetCollection()
        {
            return _mongoClient.GetDatabase(_databaseName).GetCollection<TEntity>(_collectionName ?? typeof(TEntity).Name);
        }
    }
}
