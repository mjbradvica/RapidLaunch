// <copyright file="RapidLaunchRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;
using Dapper;
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
        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="connection">An instance of the <see cref="SqlConnection"/> class.</param>
        protected RapidLaunchRepository(SqlConnection connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// Gets the <see cref="SqlConnection"/> instance.
        /// </summary>
        protected SqlConnection Connection { get;  }

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
}
