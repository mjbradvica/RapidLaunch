namespace NBaseRepository.EF
{
    using System;
    using System.Linq;
    using LongPrimary;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// A repository that accepts and <see cref="TEntity"/> with a primary key of <see cref="long"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class BaseLongRepository<TEntity> : BaseRepository<TEntity, long>
        where TEntity : class, ILongEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseLongRepository{TEntity}"/> class that has no default eager loading.
        /// </summary>
        /// <param name="context">A <see cref="DbContext"/>.</param>
        protected BaseLongRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseLongRepository{TEntity}"/> class that has eager loading.
        /// </summary>
        /// <param name="context">A <see cref="DbContext"/>.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        protected BaseLongRepository(DbContext context, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
            : base(context, includeFunc)
        {
        }
    }
}
