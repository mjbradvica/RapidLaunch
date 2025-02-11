// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using MongoDB.Driver;
using RapidLaunch.Common;

namespace RapidLaunch.Mongo.Common
{
	/// <summary>
	/// Common functions for all base RapidLaunch repositories.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <typeparam name="TId">The type of the identifier.</typeparam>
	public class RapidLaunchRepository<TEntity, TId> :
        IAddEntities<TEntity, TId>,
        IAddEntitiesAsync<TEntity, TId>,
        IAddEntity<TEntity, TId>,
        IAddEntityAsync<TEntity, TId>,
        IDeleteEntities<TEntity, TId>,
        IDeleteEntitiesAsync<TEntity, TId>,
        IDeleteEntity<TEntity, TId>,
        IDeleteEntityAsync<TEntity, TId>,
        IGetAllEntities<TEntity, TId>,
        IGetAllEntitiesAsync<TEntity, TId>,
        IGetById<TEntity, TId>,
        IGetByIdAsync<TEntity, TId>,
        IGetEntitiesById<TEntity, TId>,
        IGetEntitiesByIdAsync<TEntity, TId>,
        ISearchEntities<TEntity, TId>,
        ISearchEntitiesAsync<TEntity, TId>,
        IUpdateEntities<TEntity, TId>,
        IUpdateEntitiesAsync<TEntity, TId>,
        IUpdateEntity<TEntity, TId>,
        IUpdateEntityAsync<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        private const int SingleInsert = 1;
        private readonly MongoClient _mongoClient;
        private readonly string _databaseName;
        private readonly string? _collectionName;
        private readonly bool _useTransactions;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="mongoClient">An instance of the <see cref="MongoClient"/> class.</param>
        /// <param name="databaseName">The name of the database to use.</param>
        /// <param name="collectionName">Optional collection name.</param>
        /// <param name="useTransactions">A flag to toggle transactions on and off.</param>
        public RapidLaunchRepository(MongoClient mongoClient, string databaseName, string? collectionName = null, bool useTransactions = true)
        {
            _mongoClient = mongoClient;
            _databaseName = databaseName;
            _collectionName = collectionName;
            _useTransactions = useTransactions;
        }

        /// <inheritdoc />
        public virtual RapidLaunchStatus AddEntities(IEnumerable<TEntity> roots)
        {
            return ExecuteCommand(session =>
            {
                var aggregateRoots = roots.ToList();

                GetCollection().InsertMany(session, aggregateRoots);

                return (aggregateRoots.Count, aggregateRoots);
            });
        }

        /// <summary>
        /// Adds multiple roots to a collection and accepts an options class.
        /// </summary>
        /// <param name="roots">A <see cref="IEnumerable{T}"/> of roots to insert into a collection.</param>
        /// <param name="options">An <see cref="InsertManyOptions"/> object.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> representing the operation.</returns>
        public virtual RapidLaunchStatus AddEntities(IEnumerable<TEntity> roots, InsertManyOptions options)
        {
            return ExecuteCommand(session =>
            {
                var aggregateRoots = roots.ToList();

                GetCollection().InsertMany(session, aggregateRoots, options);

                return (aggregateRoots.Count, aggregateRoots);
            });
        }

        /// <inheritdoc />
        public virtual async Task<RapidLaunchStatus> AddEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
            {
                var aggregateRoots = entities.ToList();

                await GetCollection().InsertManyAsync(session, aggregateRoots, null, cancellationToken);

                return (aggregateRoots.Count, aggregateRoots);
            },
                cancellationToken);
        }

        /// <summary>
        /// Adds multiple entities to a collection and accepts an options class.
        /// </summary>
        /// <param name="entities">A <see cref="IEnumerable{T}"/> of entities to insert into a collection.</param>
        /// <param name="options">A <see cref="InsertManyOptions"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="RapidLaunchStatus"/> representing the asynchronous operation.</returns>
        public virtual async Task<RapidLaunchStatus> AddEntitiesAsync(IEnumerable<TEntity> entities, InsertManyOptions options, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    var aggregateRoots = entities.ToList();

                    await GetCollection().InsertManyAsync(session, aggregateRoots, options, cancellationToken);

                    return (aggregateRoots.Count, aggregateRoots);
                },
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual RapidLaunchStatus AddEntity(TEntity root)
        {
            return ExecuteCommand(session =>
            {
                GetCollection().InsertOne(session, root);

                return (SingleInsert, new List<TEntity> { root });
            });
        }

        /// <summary>
        /// Inserts a single root in the collection.
        /// </summary>
        /// <param name="root">The root to add to the collection.</param>
        /// <param name="options">A <see cref="InsertOneOptions"/> object.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> representing the operation.</returns>
        public virtual RapidLaunchStatus AddEntity(TEntity root, InsertOneOptions options)
        {
            return ExecuteCommand(session =>
            {
                GetCollection().InsertOne(session, root, options);

                return (SingleInsert, new List<TEntity> { root });
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> AddEntityAsync(TEntity root, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    await GetCollection().InsertOneAsync(session, root, null, cancellationToken);

                    return (SingleInsert, new List<TEntity> { root });
                },
                cancellationToken);
        }

        /// <summary>
        /// Inserts a single root in the collection.
        /// </summary>
        /// <param name="root">The root to add to the collection.</param>
        /// <param name="options">A <see cref="InsertOneOptions"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public virtual async Task<RapidLaunchStatus> AddEntityAsync(TEntity root, InsertOneOptions options, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    await GetCollection().InsertOneAsync(session, root, options, cancellationToken);

                    return (SingleInsert, new List<TEntity> { root });
                },
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual RapidLaunchStatus DeleteEntities(IEnumerable<TEntity> roots)
        {
            return ExecuteCommand(session =>
            {
                var aggregateRoots = roots.ToList();

                var filter = Builders<TEntity>.Filter.In(entity => entity.Id, aggregateRoots.Select(entity => entity.Id));

                GetCollection().DeleteMany(session, filter);

                return (aggregateRoots.Count, aggregateRoots);
            });
        }

        /// <summary>
        /// Deletes multiple roots from a collection.
        /// </summary>
        /// <param name="roots">A <see cref="IEnumerable{T}"/> of roots to delete.</param>
        /// <param name="options">A <see cref="DeleteOptions"/> object.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> representing the operation.</returns>
        public virtual RapidLaunchStatus DeleteEntities(IEnumerable<TEntity> roots, DeleteOptions options)
        {
            return ExecuteCommand(session =>
            {
                var aggregateRoots = roots.ToList();

                var filter = Builders<TEntity>.Filter.In(entity => entity.Id, aggregateRoots.Select(entity => entity.Id));

                GetCollection().DeleteMany(session, filter, options);

                return (aggregateRoots.Count, aggregateRoots);
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> DeleteEntitiesAsync(IEnumerable<TEntity> roots, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
            {
                var aggregateRoots = roots.ToList();

                var filter = Builders<TEntity>.Filter.In(entity => entity.Id, aggregateRoots.Select(entity => entity.Id));

                await GetCollection().DeleteManyAsync(session, filter, null, cancellationToken);

                return (aggregateRoots.Count, aggregateRoots);
            },
                cancellationToken);
        }

        /// <summary>
        /// Deletes multiple roots from a collection.
        /// </summary>
        /// <param name="roots">A <see cref="IEnumerable{T}"/> of roots to delete.</param>
        /// <param name="options">A <see cref="DeleteOptions"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public virtual async Task<RapidLaunchStatus> DeleteEntitiesAsync(IEnumerable<TEntity> roots, DeleteOptions options, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    var aggregateRoots = roots.ToList();

                    var filter = Builders<TEntity>.Filter.In(entity => entity.Id, aggregateRoots.Select(entity => entity.Id));

                    await GetCollection().DeleteManyAsync(session, filter, options, cancellationToken);

                    return (aggregateRoots.Count, aggregateRoots);
                },
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual RapidLaunchStatus DeleteEntity(TEntity root)
        {
            return ExecuteCommand(session =>
            {
                var filter = Builders<TEntity>.Filter.Eq(root => root.Id, root.Id);

                GetCollection().DeleteOne(session, filter);

                return (SingleInsert, new List<TEntity> { root });
            });
        }

        /// <summary>
        /// Deletes a single root from the collection.
        /// </summary>
        /// <param name="root">A <see cref="TEntity"/> to delete.</param>
        /// <param name="options">A <see cref="DeleteOptions"/> object.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> representing the operation.</returns>
        public virtual RapidLaunchStatus DeleteEntity(TEntity root, DeleteOptions options)
        {
            return ExecuteCommand(session =>
            {
                var filter = Builders<TEntity>.Filter.Eq(entity => entity.Id, root.Id);

                GetCollection().DeleteOne(session, filter, options);

                return (SingleInsert, new List<TEntity> { root });
            });
        }

        /// <inheritdoc />
        public virtual async Task<RapidLaunchStatus> DeleteEntityAsync(TEntity root, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    var filter = Builders<TEntity>.Filter.Eq(root => root.Id, root.Id);

                    await GetCollection().DeleteOneAsync(session, filter, null, cancellationToken);

                    return (SingleInsert, new List<TEntity> { root });
                },
                cancellationToken);
        }

        /// <summary>
        /// Deletes a single root from the collection.
        /// </summary>
        /// <param name="root">The root to remove from the collection.</param>
        /// <param name="options">A <see cref="DeleteOptions"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="RapidLaunchStatus"/> representing the asynchronous operation.</returns>
        public virtual async Task<RapidLaunchStatus> DeleteEntityAsync(TEntity root, DeleteOptions options, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    var filter = Builders<TEntity>.Filter.Eq(entity => entity.Id, root.Id);

                    await GetCollection().DeleteOneAsync(session, filter, options, cancellationToken);

                    return (SingleInsert, new List<TEntity> { root });
                },
                cancellationToken);
        }

        /// <inheritdoc/>
        public List<TEntity> GetAllEntities()
        {
            return ExecuteQuery(session =>
            {
                var filter = Builders<TEntity>.Filter.Empty;

                return GetCollection().Find(session, filter).ToCursor();
            });
        }

        /// <summary>
        /// Retrieves all entities of type from a collection.
        /// </summary>
        /// <param name="options">An instance of the <see cref="FindOptions"/> class.</param>
        /// <returns>A <see cref="List{TEntity}"/> of entities.</returns>
        public List<TEntity> GetAllEntities(FindOptions options)
        {
            return ExecuteQuery(session =>
            {
                var filter = Builders<TEntity>.Filter.Empty;

                return GetCollection().Find(session, filter, options).ToCursor();
            });
        }

        /// <inheritdoc/>
        public virtual async Task<List<TEntity>> GetAllEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(
                async session =>
            {
                var filter = Builders<TEntity>.Filter.Empty;

                return await GetCollection().FindAsync(session, filter, null, cancellationToken);
            },
                cancellationToken);
        }

        /// <summary>
        /// Returns all entities from a collection.
        /// </summary>
        /// <param name="options">A <see cref="DeleteOptions"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="List{T}"/> representing the asynchronous operation.</returns>
        public virtual async Task<List<TEntity>> GetAllEntitiesAsync(FindOptions<TEntity> options, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(
                async session =>
                {
                    var filter = Builders<TEntity>.Filter.Empty;

                    return await GetCollection().FindAsync(session, filter, options, cancellationToken);
                },
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual TEntity? GetById(TId id)
        {
            return ExecuteQuery(session =>
            {
                var filter = Builders<TEntity>.Filter.Eq(entity => entity.Id, id);

                return GetCollection().Find(session, filter).ToCursor();
            }).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves an entity by an identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <param name="options">A <see cref="FindOptions"/> object.</param>
        /// <returns>A nullable entity.</returns>
        public virtual TEntity? GetById(TId id, FindOptions options)
        {
            return ExecuteQuery(session =>
            {
                var filter = Builders<TEntity>.Filter.Eq(entity => entity.Id, id);

                return GetCollection().Find(session, filter, options).ToCursor();
            }).FirstOrDefault();
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return (await ExecuteQueryAsync(
                async session =>
                {
                    var filter = Builders<TEntity>.Filter.Eq(entity => entity.Id, id);

                    return await GetCollection().FindAsync(session, filter, null, cancellationToken);
                },
                cancellationToken))
                .FirstOrDefault();
        }

        /// <summary>
        /// Retrieves an entity by an identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <param name="options">A <see cref="FindOptions"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of nullable entity representing the asynchronous operation.</returns>
        public virtual async Task<TEntity?> GetByIdAsync(TId id, FindOptions<TEntity> options, CancellationToken cancellationToken = default)
        {
            return (await ExecuteQueryAsync(
                async session =>
                {
                    var filter = Builders<TEntity>.Filter.Eq(entity => entity.Id, id);

                    return await GetCollection().FindAsync(session, filter, options, cancellationToken);
                },
                cancellationToken))
            .FirstOrDefault();
        }

        /// <inheritdoc />
        public virtual List<TEntity> GetEntitiesById(IEnumerable<TId> identifiers)
        {
            return ExecuteQuery(session =>
            {
                var asList = identifiers.ToList();

                var filter = Builders<TEntity>.Filter.In(entity => entity.Id, asList);

                return GetCollection().Find(session, filter).ToCursor();
            });
        }

        /// <summary>
        /// Retrieves a list of entities from a range of identifiers.
        /// </summary>
        /// <param name="identifiers">A <see cref="IEnumerable{T}"/> of identifier to query against.</param>
        /// <param name="options">A <see cref="FindOptions"/> object.</param>
        /// <returns>A <see cref="List{T}"/> of entities.</returns>
        public virtual List<TEntity> GetEntitiesById(IEnumerable<TId> identifiers, FindOptions options)
        {
            return ExecuteQuery(session =>
            {
                var asList = identifiers.ToList();

                var filter = Builders<TEntity>.Filter.In(entity => entity.Id, asList);

                return GetCollection().Find(session, filter, options).ToCursor();
            });
        }

        /// <inheritdoc />
        public virtual async Task<List<TEntity>> GetEntitiesByIdAsync(IEnumerable<TId> identifiers, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(
                async session =>
                {
                    var filter = Builders<TEntity>.Filter.In(entity => entity.Id, identifiers);

                    return await GetCollection().FindAsync(session, filter, null, cancellationToken);
                },
                cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of entities from a range of identifiers.
        /// </summary>
        /// <param name="identifiers">A <see cref="IEnumerable{T}"/> of identifier to query against.</param>
        /// <param name="options">A <see cref="FindOptions"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public virtual async Task<List<TEntity>> GetEntitiesByIdAsync(IEnumerable<TId> identifiers, FindOptions<TEntity> options, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(
                async session =>
                {
                    var filter = Builders<TEntity>.Filter.In(entity => entity.Id, identifiers);

                    return await GetCollection().FindAsync(session, filter, options, cancellationToken);
                },
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual List<TEntity> SearchEntities(IQuery<TEntity> queryObject)
        {
            return ExecuteQuery(session =>
            {
                var filter = Builders<TEntity>.Filter.Where(queryObject.SearchExpression);

                return GetCollection().Find(session, filter).ToCursor();
            });
        }

        /// <summary>
        /// Performs a series of filters against a collection.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity}"/> that contains a search expression.</param>
        /// <param name="options">A <see cref="FindOptions"/> object.</param>
        /// <returns>A <see cref="List{T}"/> containing the result set.</returns>
        public virtual List<TEntity> SearchEntities(IQuery<TEntity> queryObject, FindOptions options)
        {
            return ExecuteQuery(session =>
            {
                var filter = Builders<TEntity>.Filter.Where(queryObject.SearchExpression);

                return GetCollection().Find(session, filter, options).ToCursor();
            });
        }

        /// <inheritdoc />
        public virtual async Task<List<TEntity>> SearchEntitiesAsync(IQuery<TEntity> queryObject, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(
                async session =>
            {
                var filter = Builders<TEntity>.Filter.Where(queryObject.SearchExpression);

                return await GetCollection().FindAsync(session, filter, null, cancellationToken);
            },
                cancellationToken);
        }

        /// <summary>
        /// Performs a series of filters against a collection.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity}"/> that contains a search expression.</param>
        /// <param name="options">A <see cref="FindOptions{TEntity}"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="List{T}"/> representing the asynchronous operation.</returns>
        public virtual async Task<List<TEntity>> SearchEntitiesAsync(IQuery<TEntity> queryObject, FindOptions<TEntity> options, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(
                async session =>
                {
                    var filter = Builders<TEntity>.Filter.Where(queryObject.SearchExpression);

                    return await GetCollection().FindAsync(session, filter, options, cancellationToken);
                },
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual RapidLaunchStatus UpdateEntities(IEnumerable<TEntity> entities)
        {
            return ExecuteCommand(session =>
            {
                var aggregateRoots = entities.ToList();

                var requests = aggregateRoots.Select(replacement =>
                {
                    var filter = new ExpressionFilterDefinition<TEntity>(entity => entity.Id!.Equals(replacement.Id));

                    return new ReplaceOneModel<TEntity>(filter, replacement);
                });

                GetCollection().BulkWrite(session, requests);

                return (aggregateRoots.Count, aggregateRoots);
            });
        }

        /// <summary>
        /// Updates a range of entities in a collection.
        /// </summary>
        /// <param name="entities">A <see cref="IEnumerable{T}"/> of entities to be updated.</param>
        /// <param name="options">A <see cref="BulkWriteOptions"/> object.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> representing the operation.</returns>
        public virtual RapidLaunchStatus UpdateEntities(IEnumerable<TEntity> entities, BulkWriteOptions options)
        {
            return ExecuteCommand(session =>
            {
                var aggregateRoots = entities.ToList();

                var requests = aggregateRoots.Select(replacement =>
                {
                    var filter = new ExpressionFilterDefinition<TEntity>(entity => entity.Id!.Equals(replacement.Id));

                    return new ReplaceOneModel<TEntity>(filter, replacement);
                });

                GetCollection().BulkWrite(session, requests, options);

                return (aggregateRoots.Count, aggregateRoots);
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> UpdateEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
            {
                var aggregateRoots = entities.ToList();

                var requests = aggregateRoots.Select(replacement =>
                {
                    var filter = new ExpressionFilterDefinition<TEntity>(entity => entity.Id!.Equals(replacement.Id));

                    return new ReplaceOneModel<TEntity>(filter, replacement);
                });

                await GetCollection().BulkWriteAsync(session, requests, null, cancellationToken);

                return (aggregateRoots.Count, aggregateRoots);
            },
                cancellationToken);
        }

        /// <summary>
        /// Updates a range of entities in a collection.
        /// </summary>
        /// <param name="entities">A <see cref="IEnumerable{T}"/> of entities to be updated.</param>
        /// <param name="options">A <see cref="BulkWriteOptions"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="RapidLaunchStatus"/> representing the asynchronous operation.</returns>
        public virtual async Task<RapidLaunchStatus> UpdateEntitiesAsync(IEnumerable<TEntity> entities, BulkWriteOptions options, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    var aggregateRoots = entities.ToList();

                    var requests = aggregateRoots.Select(replacement =>
                    {
                        var filter = new ExpressionFilterDefinition<TEntity>(entity => entity.Id!.Equals(replacement.Id));

                        return new ReplaceOneModel<TEntity>(filter, replacement);
                    });

                    await GetCollection().BulkWriteAsync(session, requests, options, cancellationToken);

                    return (aggregateRoots.Count, aggregateRoots);
                },
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual RapidLaunchStatus UpdateEntity(TEntity entity)
        {
            return ExecuteCommand(session =>
            {
                var filter = Builders<TEntity>.Filter.Eq(root => root.Id, entity.Id);

                GetCollection().ReplaceOne(session, filter, entity);

                return (SingleInsert, new List<TEntity> { entity });
            });
        }

        /// <summary>
        /// Updates an entity in a collection.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <param name="options">A <see cref="ReplaceOptions"/> object.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> representing the operation.</returns>
        public virtual RapidLaunchStatus UpdateEntity(TEntity entity, ReplaceOptions options)
        {
            return ExecuteCommand(session =>
            {
                var filter = Builders<TEntity>.Filter.Eq(root => root.Id, entity.Id);

                GetCollection().ReplaceOne(session, filter, entity, options);

                return (SingleInsert, new List<TEntity> { entity });
            });
        }

        /// <inheritdoc />
        public virtual async Task<RapidLaunchStatus> UpdateEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    var filter = Builders<TEntity>.Filter.Eq(root => root.Id, entity.Id);

                    await GetCollection().ReplaceOneAsync(session, filter, entity, default(ReplaceOptions), cancellationToken);

                    return (SingleInsert, new List<TEntity> { entity });
                },
                cancellationToken);
        }

        /// <summary>
        /// Updates an entity in a collection.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <param name="options">A <see cref="ReplaceOptions"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="RapidLaunchStatus"/> representing the asynchronous operation.</returns>
        public virtual async Task<RapidLaunchStatus> UpdateEntityAsync(TEntity entity, ReplaceOptions options, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    var filter = Builders<TEntity>.Filter.Eq(root => root.Id, entity.Id);

                    await GetCollection().ReplaceOneAsync(session, filter, entity, options, cancellationToken);

                    return (SingleInsert, new List<TEntity> { entity });
                },
                cancellationToken);
        }

        /// <summary>
        /// Executes a command against the persistence.
        /// </summary>
        /// <param name="executionFunc">A <see cref="Func{TResult}"/> that contains an operation to execute.</param>
        /// <param name="postOperationFunc">A <see cref="Func{TResult}"/> to run post operation effects.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> indicating the status of the operation.</returns>
        protected virtual RapidLaunchStatus ExecuteCommand(
            Func<IClientSessionHandle, (int RowCount, IEnumerable<TEntity> Entities)> executionFunc,
            Action<int, IEnumerable<IAggregateRoot<TId>>>? postOperationFunc = default)
        {
            int rowsAffected;

            using (var session = _mongoClient.StartSession())
            {
                try
                {
                    if (_useTransactions)
                    {
                        session.StartTransaction();
                    }

                    var (rowCount, aggregateRoots) = executionFunc.Invoke(session);

                    rowsAffected = rowCount;

                    postOperationFunc?.Invoke(rowsAffected, aggregateRoots);

                    if (_useTransactions)
                    {
                        session.CommitTransaction();
                    }
                }
                catch (Exception exception)
                {
                    if (_useTransactions)
                    {
                        session.AbortTransaction();
                    }

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
        protected virtual async Task<RapidLaunchStatus> ExecuteCommandAsync(Func<IClientSessionHandle, Task<(int RowCount, IEnumerable<TEntity> Entities)>> executionFunc, CancellationToken cancellationToken, Func<int, IEnumerable<IAggregateRoot<TId>>, Task>? postOperationFunc = default)
        {
            int rowsAffected;

            using (var session = await _mongoClient.StartSessionAsync(cancellationToken: cancellationToken))
            {
                try
                {
                    if (_useTransactions)
                    {
                        session.StartTransaction();
                    }

                    var (rowCount, aggregateRoots) = await executionFunc.Invoke(session);

                    rowsAffected = rowCount;

                    if (postOperationFunc != null)
                    {
                        await postOperationFunc.Invoke(rowsAffected, aggregateRoots);
                    }

                    if (_useTransactions)
                    {
                        await session.CommitTransactionAsync(cancellationToken);
                    }
                }
                catch (Exception exception)
                {
                    if (_useTransactions)
                    {
                        await session.AbortTransactionAsync(cancellationToken);
                    }

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
        protected virtual List<TEntity> ExecuteQuery(Func<IClientSessionHandle, IAsyncCursor<TEntity>> query)
        {
            var results = new List<TEntity>();

            using (var session = _mongoClient.StartSession())
            {
                var cursor = query.Invoke(session);

                if (cursor.MoveNext())
                {
                    results.AddRange(cursor.Current);
                }
            }

            return results;
        }

        /// <summary>
        /// Executes a query against the persistence.
        /// </summary>
        /// <param name="query">A <see cref="Func{TResult}"/> that executes a Mongo operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="List{T}"/> representing the asynchronous operation.</returns>
        protected virtual async Task<List<TEntity>> ExecuteQueryAsync(Func<IClientSessionHandle, Task<IAsyncCursor<TEntity>>> query, CancellationToken cancellationToken)
        {
            var results = new List<TEntity>();

            using (var session = await _mongoClient.StartSessionAsync(cancellationToken: cancellationToken))
            {
                var cursor = await query.Invoke(session);

                if (await cursor.MoveNextAsync(cancellationToken))
                {
                    results.AddRange(cursor.Current);
                }
            }

            return results;
        }

        private IMongoCollection<TEntity> GetCollection()
        {
            return _mongoClient.GetDatabase(_databaseName).GetCollection<TEntity>(_collectionName ?? typeof(TEntity).Name);
        }
    }
}
