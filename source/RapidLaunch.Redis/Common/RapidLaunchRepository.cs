// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
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
    /// <typeparam name="TRoot">The type of the root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public abstract class RapidLaunchRepository<TRoot, TId> :
        IAddRoots<TRoot, TId>,
        IAddRootsAsync<TRoot, TId>,
        IGetRootById<TRoot, TId>
        where TRoot : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TRoot, TId}"/> class.
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
        public RapidLaunchStatus AddRoots(IEnumerable<TRoot> roots)
        {
            return ExecuteCommand(() =>
            {
                var asList = roots.ToList();

                var values = asList
                    .Select(root => new KeyPathValue(root.Id!.ToString() ?? string.Empty, "$", root))
                    .ToArray();

                Database.JSON().MSet(values);

                return (values.Length, asList);
            });
        }

        /// <inheritdoc/>
        public async Task<RapidLaunchStatus> AddRootsAsync(IEnumerable<TRoot> roots, CancellationToken cancellationToken = default)
        {
            return await Task.Run(
                async () =>
            {
                try
                {
                    var values = roots
                        .Select(root => new KeyPathValue(root.Id!.ToString() ?? string.Empty, "$", root))
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
        public TRoot? GetById(TId id)
        {
            try
            {
                return Database.JSON().Get<TRoot>(id!.ToString());
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Executes a command against the persistence.
        /// </summary>
        /// <param name="executionFunc">A <see cref="Func{TResult}"/> that contains an operation to execute.</param>
        /// <param name="postOperationFunc">A <see cref="Func{TResult}"/> to run post operation effects.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> indicating the status of the operation.</returns>
        protected virtual RapidLaunchStatus ExecuteCommand(
            Func<(int RowCount, IEnumerable<TRoot> Entities)> executionFunc,
            Action<int, IEnumerable<IAggregateRoot<TId>>>? postOperationFunc = null)
        {
            int rowsAffected;

            try
            {
                var (rowCount, roots) = executionFunc.Invoke();

                rowsAffected = rowCount;

                postOperationFunc?.Invoke(rowsAffected, roots);
            }
            catch (Exception exception)
            {
                return RapidLaunchStatus.Failed(exception);
            }

            return RapidLaunchStatus.Success(rowsAffected);
        }
    }
}
