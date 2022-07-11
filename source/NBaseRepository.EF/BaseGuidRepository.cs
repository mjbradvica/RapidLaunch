namespace NBaseRepository.EF
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using GuidPrimary;

    /// <summary>
    /// A repository that accepts and <see cref="TEntity"/> with a primary key of <see cref="Guid"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class BaseGuidRepository<TEntity> : BaseRepository<TEntity, Guid>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseGuidRepository{TEntity}"/> class that has no default eager loading.
        /// </summary>
        /// <param name="context">A <see cref="DbContext"/>.</param>
        protected BaseGuidRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseGuidRepository{TEntity}"/> class that has eager loading.
        /// </summary>
        /// <param name="context">A <see cref="DbContext"/>.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        protected BaseGuidRepository(DbContext context, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
            : base(context, includeFunc)
        {
        }
    }
}
