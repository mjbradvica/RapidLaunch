// <copyright file="RapidLaunchRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using NRedisStack.Json.DataTypes;
using NRedisStack.RedisStackCommands;
using RapidLaunch.Common;
using StackExchange.Redis;

namespace RapidLaunch.Redis.Common
{
	/// <summary>
	/// Common functions for all base RapidLaunch repositories.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <typeparam name="TId">The type of the identifier.</typeparam>
	public abstract class RapidLaunchRepository<TEntity, TId> :
        IAddEntities<TEntity, TId>,
        IAddEntitiesAsync<TEntity, TId>,
        IGetById<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="database">An instance of the <see cref="IDatabase"/> interface.</param>
        protected RapidLaunchRepository(IDatabase database)
        {
            Database = database;
        }

        /// <summary>
        /// Gets the database instance.
        /// </summary>
        public IDatabase Database { get; }

        /// <inheritdoc />
        public RapidLaunchStatus AddEntities(IEnumerable<TEntity> entities)
        {
            return ExecuteCommand(() =>
            {
                var asList = entities.ToList();

                var values = asList
                    .Select(entity => new KeyPathValue(entity.Id!.ToString() ?? string.Empty, "$", entity))
                    .ToArray();

                Database.JSON().MSet(values);

                return (values.Length, asList);
            });
        }

        /// <inheritdoc/>
        public async Task<RapidLaunchStatus> AddEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return await Task.Run(
                async () =>
            {
                try
                {
                    var values = entities
                        .Select(entity => new KeyPathValue(entity.Id!.ToString() ?? string.Empty, "$", entity))
                        .ToArray();

                    await Database.JSON().MSetAsync(values);

                    return RapidLaunchStatus.Success(values.Length);
                }
                catch (Exception exception)
                {
                    return RapidLaunchStatus.Failed(exception);
                }
            },
                cancellationToken);
        }

        /// <inheritdoc />
        public TEntity? GetById(TId id)
        {
            try
            {
                return Database.JSON().Get<TEntity>(id!.ToString());
            }
            catch
            {
                return default;
            }
        }

        /// <summary>
        /// Executes a command against the persistence.
        /// </summary>
        /// <param name="executionFunc">A <see cref="Func{TResult}"/> that contains an operation to execute.</param>
        /// <param name="postOperationFunc">A <see cref="Func{TResult}"/> to run post operation effects.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> indicating the status of the operation.</returns>
        protected virtual RapidLaunchStatus ExecuteCommand(
            Func<(int RowCount, IEnumerable<TEntity> Entities)> executionFunc,
            Action<int, IEnumerable<IAggregateRoot<TId>>>? postOperationFunc = default)
        {
            int rowsAffected;

            try
            {
                var (rowCount, entities) = executionFunc.Invoke();

                rowsAffected = rowCount;

                postOperationFunc?.Invoke(rowsAffected, entities);
            }
            catch (Exception exception)
            {
                return RapidLaunchStatus.Failed(exception);
            }

            return RapidLaunchStatus.Success(rowsAffected);
        }
    }
}
