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
    /// <typeparam name="TRoot">The type of the root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public class RapidLaunchRepository<TRoot, TId> :
        IAddRoots<TRoot, TId>,
        IAddRootsAsync<TRoot, TId>,
        IAddRoot<TRoot, TId>,
        IAddRootAsync<TRoot, TId>,
        IDeleteRoots<TRoot, TId>,
        IDeleteRootsAsync<TRoot, TId>,
        IDeleteRoot<TRoot, TId>,
        IDeleteRootAsync<TRoot, TId>,
        IGetAllRoots<TRoot, TId>,
        IGetAllRootsAsync<TRoot, TId>,
        IGetRootById<TRoot, TId>,
        IGetRootByIdAsync<TRoot, TId>,
        IGetRootsById<TRoot, TId>,
        IGetRootsByIdAsync<TRoot, TId>,
        ISearchRoots<TRoot, TId>,
        ISearchRootsAsync<TRoot, TId>,
        IUpdateRoots<TRoot, TId>,
        IUpdateRootsAsync<TRoot, TId>,
        IUpdateRoot<TRoot, TId>,
        IUpdateRootAsync<TRoot, TId>
        where TRoot : class, IAggregateRoot<TId>
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
        protected RapidLaunchRepository(MongoClient mongoClient, string databaseName, string? collectionName = null, bool useTransactions = true)
        {
            _mongoClient = mongoClient;
            _databaseName = databaseName;
            _collectionName = collectionName;
            _useTransactions = useTransactions;
        }

        /// <inheritdoc />
        public virtual RapidLaunchStatus AddRoots(IEnumerable<TRoot> roots)
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
        public virtual RapidLaunchStatus AddEntities(IEnumerable<TRoot> roots, InsertManyOptions options)
        {
            return ExecuteCommand(session =>
            {
                var aggregateRoots = roots.ToList();

                GetCollection().InsertMany(session, aggregateRoots, options);

                return (aggregateRoots.Count, aggregateRoots);
            });
        }

        /// <inheritdoc />
        public virtual async Task<RapidLaunchStatus> AddRootsAsync(IEnumerable<TRoot> roots, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
            {
                var aggregateRoots = roots.ToList();

                await GetCollection().InsertManyAsync(session, aggregateRoots, null, cancellationToken);

                return (aggregateRoots.Count, aggregateRoots);
            },
                cancellationToken);
        }

        /// <summary>
        /// Adds multiple roots to a collection and accepts an options class.
        /// </summary>
        /// <param name="roots">A <see cref="IEnumerable{T}"/> of roots to insert into a collection.</param>
        /// <param name="options">A <see cref="InsertManyOptions"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="RapidLaunchStatus"/> representing the asynchronous operation.</returns>
        public virtual async Task<RapidLaunchStatus> AddEntitiesAsync(IEnumerable<TRoot> roots, InsertManyOptions options, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    var aggregateRoots = roots.ToList();

                    await GetCollection().InsertManyAsync(session, aggregateRoots, options, cancellationToken);

                    return (aggregateRoots.Count, aggregateRoots);
                },
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual RapidLaunchStatus AddRoot(TRoot root)
        {
            return ExecuteCommand(session =>
            {
                GetCollection().InsertOne(session, root);

                return (SingleInsert, new List<TRoot> { root });
            });
        }

        /// <summary>
        /// Inserts a single root in the collection.
        /// </summary>
        /// <param name="root">The root to add to the collection.</param>
        /// <param name="options">A <see cref="InsertOneOptions"/> object.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> representing the operation.</returns>
        public virtual RapidLaunchStatus AddEntity(TRoot root, InsertOneOptions options)
        {
            return ExecuteCommand(session =>
            {
                GetCollection().InsertOne(session, root, options);

                return (SingleInsert, new List<TRoot> { root });
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> AddRootAsync(TRoot root, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    await GetCollection().InsertOneAsync(session, root, null, cancellationToken);

                    return (SingleInsert, new List<TRoot> { root });
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
        public virtual async Task<RapidLaunchStatus> AddEntityAsync(TRoot root, InsertOneOptions options, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    await GetCollection().InsertOneAsync(session, root, options, cancellationToken);

                    return (SingleInsert, new List<TRoot> { root });
                },
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual RapidLaunchStatus DeleteRoots(IEnumerable<TRoot> roots)
        {
            return ExecuteCommand(session =>
            {
                var aggregateRoots = roots.ToList();

                var filter = Builders<TRoot>.Filter.In(root => root.Id, aggregateRoots.Select(root => root.Id));

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
        public virtual RapidLaunchStatus DeleteEntities(IEnumerable<TRoot> roots, DeleteOptions options)
        {
            return ExecuteCommand(session =>
            {
                var aggregateRoots = roots.ToList();

                var filter = Builders<TRoot>.Filter.In(root => root.Id, aggregateRoots.Select(root => root.Id));

                GetCollection().DeleteMany(session, filter, options);

                return (aggregateRoots.Count, aggregateRoots);
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> DeleteRootsAsync(IEnumerable<TRoot> roots, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
            {
                var aggregateRoots = roots.ToList();

                var filter = Builders<TRoot>.Filter.In(root => root.Id, aggregateRoots.Select(root => root.Id));

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
        public virtual async Task<RapidLaunchStatus> DeleteEntitiesAsync(IEnumerable<TRoot> roots, DeleteOptions options, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    var aggregateRoots = roots.ToList();

                    var filter = Builders<TRoot>.Filter.In(root => root.Id, aggregateRoots.Select(root => root.Id));

                    await GetCollection().DeleteManyAsync(session, filter, options, cancellationToken);

                    return (aggregateRoots.Count, aggregateRoots);
                },
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual RapidLaunchStatus DeleteRoot(TRoot root)
        {
            return ExecuteCommand(session =>
            {
                var filter = Builders<TRoot>.Filter.Eq(root => root.Id, root.Id);

                GetCollection().DeleteOne(session, filter);

                return (SingleInsert, new List<TRoot> { root });
            });
        }

        /// <summary>
        /// Deletes a single root from the collection.
        /// </summary>
        /// <param name="root">A <typeparamref name="TRoot"/> to delete.</param>
        /// <param name="options">A <see cref="DeleteOptions"/> object.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> representing the operation.</returns>
        public virtual RapidLaunchStatus DeleteEntity(TRoot root, DeleteOptions options)
        {
            return ExecuteCommand(session =>
            {
                var filter = Builders<TRoot>.Filter.Eq(aggregateRoot => aggregateRoot.Id, root.Id);

                GetCollection().DeleteOne(session, filter, options);

                return (SingleInsert, new List<TRoot> { root });
            });
        }

        /// <inheritdoc />
        public virtual async Task<RapidLaunchStatus> DeleteRootAsync(TRoot root, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    var filter = Builders<TRoot>.Filter.Eq(root => root.Id, root.Id);

                    await GetCollection().DeleteOneAsync(session, filter, null, cancellationToken);

                    return (SingleInsert, new List<TRoot> { root });
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
        public virtual async Task<RapidLaunchStatus> DeleteEntityAsync(TRoot root, DeleteOptions options, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    var filter = Builders<TRoot>.Filter.Eq(root => root.Id, root.Id);

                    await GetCollection().DeleteOneAsync(session, filter, options, cancellationToken);

                    return (SingleInsert, new List<TRoot> { root });
                },
                cancellationToken);
        }

        /// <inheritdoc/>
        public List<TRoot> GetAllRoots()
        {
            return ExecuteQuery(session =>
            {
                var filter = Builders<TRoot>.Filter.Empty;

                return GetCollection().Find(session, filter).ToCursor();
            });
        }

        /// <summary>
        /// Retrieves all roots of type from a collection.
        /// </summary>
        /// <param name="options">An instance of the <see cref="FindOptions"/> class.</param>
        /// <returns>A <see cref="List{TEntity}"/> of roots.</returns>
        public List<TRoot> GetAllEntities(FindOptions options)
        {
            return ExecuteQuery(session =>
            {
                var filter = Builders<TRoot>.Filter.Empty;

                return GetCollection().Find(session, filter, options).ToCursor();
            });
        }

        /// <inheritdoc/>
        public virtual async Task<List<TRoot>> GetAllRootsAsync(CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(
                async session =>
            {
                var filter = Builders<TRoot>.Filter.Empty;

                return await GetCollection().FindAsync(session, filter, null, cancellationToken);
            },
                cancellationToken);
        }

        /// <summary>
        /// Returns all roots from a collection.
        /// </summary>
        /// <param name="options">A <see cref="DeleteOptions"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="List{T}"/> representing the asynchronous operation.</returns>
        public virtual async Task<List<TRoot>> GetAllEntitiesAsync(FindOptions<TRoot> options, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(
                async session =>
                {
                    var filter = Builders<TRoot>.Filter.Empty;

                    return await GetCollection().FindAsync(session, filter, options, cancellationToken);
                },
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual TRoot? GetById(TId id)
        {
            return ExecuteQuery(session =>
            {
                var filter = Builders<TRoot>.Filter.Eq(root => root.Id, id);

                return GetCollection().Find(session, filter).ToCursor();
            }).FirstOrDefault();
        }

        /// <summary>
        /// Retrieves an root by an identifier.
        /// </summary>
        /// <param name="id">The identifier of the root.</param>
        /// <param name="options">A <see cref="FindOptions"/> object.</param>
        /// <returns>A nullable root.</returns>
        public virtual TRoot? GetById(TId id, FindOptions options)
        {
            return ExecuteQuery(session =>
            {
                var filter = Builders<TRoot>.Filter.Eq(root => root.Id, id);

                return GetCollection().Find(session, filter, options).ToCursor();
            }).FirstOrDefault();
        }

        /// <inheritdoc/>
        public virtual async Task<TRoot?> GetRootByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return (await ExecuteQueryAsync(
                async session =>
                {
                    var filter = Builders<TRoot>.Filter.Eq(root => root.Id, id);

                    return await GetCollection().FindAsync(session, filter, null, cancellationToken);
                },
                cancellationToken))
                .FirstOrDefault();
        }

        /// <summary>
        /// Retrieves an root by an identifier.
        /// </summary>
        /// <param name="id">The identifier of the root.</param>
        /// <param name="options">A <see cref="FindOptions"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of nullable root representing the asynchronous operation.</returns>
        public virtual async Task<TRoot?> GetByIdAsync(TId id, FindOptions<TRoot> options, CancellationToken cancellationToken = default)
        {
            return (await ExecuteQueryAsync(
                async session =>
                {
                    var filter = Builders<TRoot>.Filter.Eq(root => root.Id, id);

                    return await GetCollection().FindAsync(session, filter, options, cancellationToken);
                },
                cancellationToken))
            .FirstOrDefault();
        }

        /// <inheritdoc />
        public virtual List<TRoot> GetRootsById(IEnumerable<TId> identifiers)
        {
            return ExecuteQuery(session =>
            {
                var asList = identifiers.ToList();

                var filter = Builders<TRoot>.Filter.In(root => root.Id, asList);

                return GetCollection().Find(session, filter).ToCursor();
            });
        }

        /// <summary>
        /// Retrieves a list of roots from a range of identifiers.
        /// </summary>
        /// <param name="identifiers">A <see cref="IEnumerable{T}"/> of identifier to query against.</param>
        /// <param name="options">A <see cref="FindOptions"/> object.</param>
        /// <returns>A <see cref="List{T}"/> of roots.</returns>
        public virtual List<TRoot> GetEntitiesById(IEnumerable<TId> identifiers, FindOptions options)
        {
            return ExecuteQuery(session =>
            {
                var asList = identifiers.ToList();

                var filter = Builders<TRoot>.Filter.In(root => root.Id, asList);

                return GetCollection().Find(session, filter, options).ToCursor();
            });
        }

        /// <inheritdoc />
        public virtual async Task<List<TRoot>> GetRootsByIdAsync(IEnumerable<TId> identifiers, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(
                async session =>
                {
                    var filter = Builders<TRoot>.Filter.In(root => root.Id, identifiers);

                    return await GetCollection().FindAsync(session, filter, null, cancellationToken);
                },
                cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of roots from a range of identifiers.
        /// </summary>
        /// <param name="identifiers">A <see cref="IEnumerable{T}"/> of identifier to query against.</param>
        /// <param name="options">A <see cref="FindOptions"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public virtual async Task<List<TRoot>> GetEntitiesByIdAsync(IEnumerable<TId> identifiers, FindOptions<TRoot> options, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(
                async session =>
                {
                    var filter = Builders<TRoot>.Filter.In(root => root.Id, identifiers);

                    return await GetCollection().FindAsync(session, filter, options, cancellationToken);
                },
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual List<TRoot> SearchRoots(IQuery<TRoot, TId> queryObject)
        {
            return ExecuteQuery(session =>
            {
                var filter = Builders<TRoot>.Filter.Where(queryObject.SearchExpression);

                return GetCollection().Find(session, filter).ToCursor();
            });
        }

        /// <summary>
        /// Performs a series of filters against a collection.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity, TId}"/> that contains a search expression.</param>
        /// <param name="options">A <see cref="FindOptions"/> object.</param>
        /// <returns>A <see cref="List{T}"/> containing the result set.</returns>
        public virtual List<TRoot> SearchEntities(IQuery<TRoot, TId> queryObject, FindOptions options)
        {
            return ExecuteQuery(session =>
            {
                var filter = Builders<TRoot>.Filter.Where(queryObject.SearchExpression);

                return GetCollection().Find(session, filter, options).ToCursor();
            });
        }

        /// <inheritdoc />
        public virtual async Task<List<TRoot>> SearchRootsAsync(IQuery<TRoot, TId> queryObject, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(
                async session =>
            {
                var filter = Builders<TRoot>.Filter.Where(queryObject.SearchExpression);

                return await GetCollection().FindAsync(session, filter, null, cancellationToken);
            },
                cancellationToken);
        }

        /// <summary>
        /// Performs a series of filters against a collection.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity, TId}"/> that contains a search expression.</param>
        /// <param name="options">A <see cref="FindOptions{TEntity}"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="List{T}"/> representing the asynchronous operation.</returns>
        public virtual async Task<List<TRoot>> SearchEntitiesAsync(IQuery<TRoot, TId> queryObject, FindOptions<TRoot> options, CancellationToken cancellationToken = default)
        {
            return await ExecuteQueryAsync(
                async session =>
                {
                    var filter = Builders<TRoot>.Filter.Where(queryObject.SearchExpression);

                    return await GetCollection().FindAsync(session, filter, options, cancellationToken);
                },
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual RapidLaunchStatus UpdateRoots(IEnumerable<TRoot> roots)
        {
            return ExecuteCommand(session =>
            {
                var aggregateRoots = roots.ToList();

                var requests = aggregateRoots.Select(replacement =>
                {
                    var filter = new ExpressionFilterDefinition<TRoot>(root => root.Id!.Equals(replacement.Id));

                    return new ReplaceOneModel<TRoot>(filter, replacement);
                });

                GetCollection().BulkWrite(session, requests);

                return (aggregateRoots.Count, aggregateRoots);
            });
        }

        /// <summary>
        /// Updates a range of roots in a collection.
        /// </summary>
        /// <param name="roots">A <see cref="IEnumerable{T}"/> of roots to be updated.</param>
        /// <param name="options">A <see cref="BulkWriteOptions"/> object.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> representing the operation.</returns>
        public virtual RapidLaunchStatus UpdateEntities(IEnumerable<TRoot> roots, BulkWriteOptions options)
        {
            return ExecuteCommand(session =>
            {
                var aggregateRoots = roots.ToList();

                var requests = aggregateRoots.Select(replacement =>
                {
                    var filter = new ExpressionFilterDefinition<TRoot>(root => root.Id!.Equals(replacement.Id));

                    return new ReplaceOneModel<TRoot>(filter, replacement);
                });

                GetCollection().BulkWrite(session, requests, options);

                return (aggregateRoots.Count, aggregateRoots);
            });
        }

        /// <inheritdoc/>
        public virtual async Task<RapidLaunchStatus> UpdateRootsAsync(IEnumerable<TRoot> roots, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
            {
                var aggregateRoots = roots.ToList();

                var requests = aggregateRoots.Select(replacement =>
                {
                    var filter = new ExpressionFilterDefinition<TRoot>(root => root.Id!.Equals(replacement.Id));

                    return new ReplaceOneModel<TRoot>(filter, replacement);
                });

                await GetCollection().BulkWriteAsync(session, requests, null, cancellationToken);

                return (aggregateRoots.Count, aggregateRoots);
            },
                cancellationToken);
        }

        /// <summary>
        /// Updates a range of roots in a collection.
        /// </summary>
        /// <param name="roots">A <see cref="IEnumerable{T}"/> of roots to be updated.</param>
        /// <param name="options">A <see cref="BulkWriteOptions"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="RapidLaunchStatus"/> representing the asynchronous operation.</returns>
        public virtual async Task<RapidLaunchStatus> UpdateEntitiesAsync(IEnumerable<TRoot> roots, BulkWriteOptions options, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    var aggregateRoots = roots.ToList();

                    var requests = aggregateRoots.Select(replacement =>
                    {
                        var filter = new ExpressionFilterDefinition<TRoot>(root => root.Id!.Equals(replacement.Id));

                        return new ReplaceOneModel<TRoot>(filter, replacement);
                    });

                    await GetCollection().BulkWriteAsync(session, requests, options, cancellationToken);

                    return (aggregateRoots.Count, aggregateRoots);
                },
                cancellationToken);
        }

        /// <inheritdoc />
        public virtual RapidLaunchStatus UpdateRoot(TRoot root)
        {
            return ExecuteCommand(session =>
            {
                var filter = Builders<TRoot>.Filter.Eq(aggregateRoot => aggregateRoot.Id, root.Id);

                GetCollection().ReplaceOne(session, filter, root);

                return (SingleInsert, new List<TRoot> { root });
            });
        }

        /// <summary>
        /// Updates a root in a collection.
        /// </summary>
        /// <param name="root">A <typeparamref name="TRoot"/>.</param>
        /// <param name="options">A <see cref="ReplaceOptions"/> object.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> representing the operation.</returns>
        public virtual RapidLaunchStatus UpdateEntity(TRoot root, ReplaceOptions options)
        {
            return ExecuteCommand(session =>
            {
                var filter = Builders<TRoot>.Filter.Eq(aggregateRoot => aggregateRoot.Id, root.Id);

                GetCollection().ReplaceOne(session, filter, root, options);

                return (SingleInsert, new List<TRoot> { root });
            });
        }

        /// <inheritdoc />
        public virtual async Task<RapidLaunchStatus> UpdateRootAsync(TRoot root, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    var filter = Builders<TRoot>.Filter.Eq(root => root.Id, root.Id);

                    await GetCollection().ReplaceOneAsync(session, filter, root, default(ReplaceOptions), cancellationToken);

                    return (SingleInsert, new List<TRoot> { root });
                },
                cancellationToken);
        }

        /// <summary>
        /// Updates a root in a collection.
        /// </summary>
        /// <param name="root">The <typeparamref name="TRoot"/> to update.</param>
        /// <param name="options">A <see cref="ReplaceOptions"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="RapidLaunchStatus"/> representing the asynchronous operation.</returns>
        public virtual async Task<RapidLaunchStatus> UpdateEntityAsync(TRoot root, ReplaceOptions options, CancellationToken cancellationToken = default)
        {
            return await ExecuteCommandAsync(
                async session =>
                {
                    var filter = Builders<TRoot>.Filter.Eq(aggregateRoot => aggregateRoot.Id, root.Id);

                    await GetCollection().ReplaceOneAsync(session, filter, root, options, cancellationToken);

                    return (SingleInsert, new List<TRoot> { root });
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
            Func<IClientSessionHandle, (int RowCount, IEnumerable<TRoot> Entities)> executionFunc,
            Action<int, IEnumerable<IAggregateRoot<TId>>>? postOperationFunc = null)
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
        protected virtual async Task<RapidLaunchStatus> ExecuteCommandAsync(Func<IClientSessionHandle, Task<(int RowCount, IEnumerable<TRoot> Entities)>> executionFunc, CancellationToken cancellationToken, Func<int, IEnumerable<IAggregateRoot<TId>>, Task>? postOperationFunc = null)
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
        /// <returns>A <see cref="List{T}"/> of roots.</returns>
        protected virtual List<TRoot> ExecuteQuery(Func<IClientSessionHandle, IAsyncCursor<TRoot>> query)
        {
            var results = new List<TRoot>();

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
        protected virtual async Task<List<TRoot>> ExecuteQueryAsync(Func<IClientSessionHandle, Task<IAsyncCursor<TRoot>>> query, CancellationToken cancellationToken)
        {
            var results = new List<TRoot>();

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

        private IMongoCollection<TRoot> GetCollection()
        {
            return _mongoClient.GetDatabase(_databaseName).GetCollection<TRoot>(_collectionName ?? typeof(TRoot).Name);
        }
    }
}
