﻿// <copyright file="NBaseCoreRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NBaseRepository.Common;
using NBaseRepository.EF.Base.Common;

namespace NBaseRepository.EF.Common
{
    /// <summary>
    /// A base repository of type <see cref="TEntity"/> with an Id of type <see cref="TId"/> that represents all possible operations.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public abstract class NBaseCoreRepository<TEntity, TId> :
        IAddEntity<TEntity, TId>,
        IAddEntityAsync<TEntity, TId>,
        IAddEntities<TEntity, TId>,
        IAddEntitiesAsync<TEntity, TId>,
        IGetById<TEntity, TId>,
        IGetByIdAsync<TEntity, TId>,
        IGetAllEntities<TEntity, TId>,
        IGetAllEntitiesAsync<TEntity, TId>,
        IGetAllEntitiesLazy<TEntity, TId>,
        IUpdateEntity<TEntity, TId>,
        IUpdateEntityAsync<TEntity, TId>,
        IUpdateEntities<TEntity, TId>,
        IUpdateEntitiesAsync<TEntity, TId>,
        IDeleteById<TId>,
        IDeleteByIdAsync<TId>,
        IDeleteEntity<TEntity, TId>,
        IDeleteEntityAsync<TEntity, TId>,
        IDeleteEntities<TEntity, TId>,
        IDeleteEntitiesAsync<TEntity, TId>,
        ISearchEntities<TEntity, TId>,
        ISearchEntitiesAsync<TEntity, TId>,
        ISearchEntitiesLazy<TEntity, TId>
        where TEntity : class, IEntity<TId>
        where TId : struct
    {
        private readonly Func<IQueryable<TEntity>, IQueryable<TEntity>> _includeFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseCoreRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="context"></param>
        protected NBaseCoreRepository(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseCoreRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="includeFunc"></param>
        protected NBaseCoreRepository(DbContext context, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            Context = context;
            _includeFunc = includeFunc;
        }

        protected DbContext Context { get; }

        /// <summary>
        /// Adds a single <see cref="TEntity"/> to the database.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be added to the database.</param>
        /// <returns>The result contains the number of state entries written to the database.</returns>
        public virtual int AddEntity(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);

            return Context.SaveChanges();
        }

        /// <summary>
        /// Adds a single <see cref="TEntity"/> to the database.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be added to the database.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous save operation. The task result contains the a state entry written to the database.</returns>
        public virtual async Task<int> AddEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Context.Set<TEntity>().AddAsync(entity, cancellationToken);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Adds multiple <see cref="TEntity"/>s to the database.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to add to the database.</param>
        /// <returns>The result contains the number of state entries written to the database.</returns>
        public virtual int AddEntities(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);

            return Context.SaveChanges();
        }

        /// <summary>
        /// Adds multiple <see cref="TEntity"/>s to the database.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to add to the database.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
        public virtual async Task<int> AddEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves an <see cref="TEntity"/> from the database by Id.
        /// </summary>
        /// <param name="id">An Id of type <see cref="TId"/>.</param>
        /// <returns>A <see cref="TEntity"/>.</returns>
        public virtual TEntity GetById(TId id)
        {
            return EntityContext().First(entity => entity.Id.Equals(id));
        }

        /// <summary>
        /// Retrieves an entity from the database by <see cref="TId"/> that accepts a custom include func for eager loading.
        /// </summary>
        /// <param name="id">An Id of type <see cref="TId"/>.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous get operation. The task results contains the <see cref="TEntity"/>.</returns>
        public virtual TEntity GetById(TId id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            return includeFunc.Invoke(Context.Set<TEntity>()).First(entity => entity.Id.Equals(id));
        }

        /// <summary>
        /// Retrieves an <see cref="TEntity"/> from the database by Id.
        /// </summary>
        /// <param name="id">An Id of type <see cref="TId"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous get operation. The task results contains the <see cref="TEntity"/>.</returns>
        public virtual async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return await EntityContext().FirstAsync(entity => entity.Id.Equals(id), cancellationToken);
        }

        /// <summary>
        /// Retrieves an entity from the database by <see cref="TId"/> that accepts a custom include func for eager loading.
        /// </summary>
        /// <param name="id">An Id of type <see cref="TId"/>.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous get operation. The task results contains the <see cref="TEntity"/>.</returns>
        public virtual async Task<TEntity> GetByIdAsync(TId id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await includeFunc.Invoke(Context.Set<TEntity>()).FirstAsync(entity => entity.Id.Equals(id), cancellationToken);
        }

        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from the database.
        /// </summary>
        /// <returns>An <see cref="IReadOnlyList{TEntity}"/>.</returns>
        public virtual IReadOnlyList<TEntity> GetAllEntities()
        {
            return Context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from the database that accepts a custom include func for eager loading.
        /// </summary>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <returns>An <see cref="IReadOnlyList{TEntity}"/>.</returns>
        public virtual IReadOnlyList<TEntity> GetAllEntities(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            return includeFunc.Invoke(Context.Set<TEntity>()).ToList();
        }

        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from the database.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous get all operations. The task results contains an <see cref="IReadOnlyList{TEntity}"/>.</returns>
        public virtual async Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await EntityContext().ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from the database that accepts a custom include func for eager loading.
        /// </summary>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous get all operations. The task results contains an <see cref="IReadOnlyList{TEntity}"/>.</returns>
        public virtual async Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await includeFunc.Invoke(Context.Set<TEntity>()).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from the database that may still be queried against.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{TEntity}"/>.</returns>
        public virtual IEnumerable<TEntity> GetAllEntitiesLazy()
        {
            return EntityContext();
        }

        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from the database that accepts a custom include func for eager loading that may still be queried against.
        /// </summary>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <returns>An <see cref="IEnumerable{TEntity}"/>.</returns>
        public virtual IEnumerable<TEntity> GetAllEntitiesLazy(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            return includeFunc.Invoke(Context.Set<TEntity>());
        }

        /// <summary>
        /// Updates an <see cref="TEntity"/> in the database.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be updated.</param>
        /// <returns>A <see cref="int"/> that contains the number of state entities updated in the database.</returns>
        public virtual int UpdateEntity(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);

            return Context.SaveChanges();
        }

        /// <summary>
        /// Updates an <see cref="TEntity"/> in the database.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be updated.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous update operation. The task result contains the state entry updated in the database.</returns>
        public virtual async Task<int> UpdateEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().Update(entity);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Updates a range <see cref="TEntity"/> in the database.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to be updated.</param>
        /// <returns>A <see cref="int"/> that contains the number of state entries updated in the database.</returns>
        public virtual int UpdateEntities(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);

            return Context.SaveChanges();
        }

        /// <summary>
        /// Updates a range <see cref="TEntity"/> in the database.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to be updated.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous update operation. The task result contains the number of state entries updated in the database.</returns>
        public virtual async Task<int> UpdateEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().UpdateRange(entities);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Removes an entity from the database by <see cref="TId"/>.
        /// </summary>
        /// <param name="id">The <see cref="TId"/> used to delete the entity.</param>
        /// <returns>An <see cref="int"/> the number of state entries deleted from the database.</returns>
        public virtual int DeleteById(TId id)
        {
            var entity = GetById(id);

            return DeleteEntity(entity);
        }

        /// <summary>
        /// Removes an entity from the database by <see cref="TId"/>.
        /// </summary>
        /// <param name="id">The <see cref="TId"/> used to delete the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation. The task result contains the state entry deleted from the database.</returns>
        public virtual async Task<int> DeleteByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);

            return await DeleteEntityAsync(entity, cancellationToken);
        }

        /// <summary>
        /// Removes an <see cref="TEntity"/> from the database.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be deleted.</param>
        /// <returns>An <see cref="int"/> that contains the number of state entries deleted from the database.</returns>
        public virtual int DeleteEntity(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);

            return Context.SaveChanges();
        }

        /// <summary>
        /// Removes an <see cref="TEntity"/> from the database.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation. The task result contains the number of state entries deleted from the database.</returns>
        public virtual async Task<int> DeleteEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().Remove(entity);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Removes multiple <see cref="TEntity"/> from the database.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to be deleted.</param>
        /// <returns>A <see cref="int"/> that contains the number of state entries deleted from the database.</returns>
        public virtual int DeleteEntities(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);

            return Context.SaveChanges();
        }

        /// <summary>
        /// Removes multiple <see cref="TEntity"/> from the database.
        /// </summary>
        /// <param name="entities">An <see cref="IEnumerable{TEntity}"/> to be deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation. The task result contains the number of state entries deleted from the database.</returns>
        public virtual async Task<int> DeleteEntitiesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().RemoveRange(entities);

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Performs a series of filters and/or joins on a <see cref="TEntity"/> against the database.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity}"/> that contains a query expression.</param>
        /// <returns>A <see cref="IReadOnlyList{TEntity}"/>.</returns>
        public virtual IReadOnlyList<TEntity> SearchEntities(IQuery<TEntity> queryObject)
        {
            return EntityContext().Where(queryObject.SearchExpression).ToList();
        }

        /// <summary>
        /// Performs a series of filters and/or joins on a <see cref="TEntity"/> that accepts a customer include func for eager loading against the database.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity}"/> that contains a query expression.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <returns>A <see cref="IReadOnlyList{TEntity}"/>.</returns>
        public virtual IReadOnlyList<TEntity> SearchEntities(IQuery<TEntity> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            return includeFunc.Invoke(Context.Set<TEntity>()).Where(queryObject.SearchExpression).ToList();
        }

        /// <summary>
        /// Performs a series of filters and/or joins on a <see cref="TEntity"/> against the database.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity}"/> that contains a query expression.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous get all operations. The task results contains an <see cref="IReadOnlyList{TEntity}"/>.</returns>
        public virtual async Task<IReadOnlyList<TEntity>> SearchEntitiesAsync(IQuery<TEntity> queryObject, CancellationToken cancellationToken = default)
        {
            return await EntityContext().Where(queryObject.SearchExpression).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Performs a series of filters and/or joins on a <see cref="TEntity"/> that accepts a customer include func for eager loading against the database.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity}"/> that contains a query expression.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous get all operations. The task results contains an <see cref="IReadOnlyList{TEntity}"/>.</returns>
        public virtual async Task<IReadOnlyList<TEntity>> SearchEntitiesAsync(IQuery<TEntity> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken = default)
        {
            return await includeFunc.Invoke(Context.Set<TEntity>()).Where(queryObject.SearchExpression).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Performs a series of filters and/or joins on a <see cref="TEntity"/> against the database that has not been executed.
        /// </summary>
        /// <param name="queryObject">A query object that contains a query expression.</param>
        /// <returns>An <see cref="IEnumerable{TEntity}"/> that may be queried against.</returns>
        public virtual IEnumerable<TEntity> SearchEntitiesLazy(IQuery<TEntity> queryObject)
        {
            return EntityContext().Where(queryObject.SearchExpression);
        }

        /// <summary>
        /// Performs a series of filters and/or joins on a <see cref="TEntity"/> against the database that accepts a customer include func that has not been executed.
        /// </summary>
        /// <param name="queryObject">A query object of type <see cref="IQuery{TEntity}"/> that contains a query expression.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <returns>An <see cref="IEnumerable{TEntity}"/> that may be queried against.</returns>
        public virtual IEnumerable<TEntity> SearchEntitiesLazy(IQuery<TEntity> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            return includeFunc.Invoke(Context.Set<TEntity>()).Where(queryObject.SearchExpression);
        }

        private IQueryable<TEntity> EntityContext()
        {
            return _includeFunc != null ? _includeFunc.Invoke(Context.Set<TEntity>()) : Context.Set<TEntity>();
        }
    }
}
