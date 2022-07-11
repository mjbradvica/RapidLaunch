using NBaseRepository.GuidPrimary;

namespace NBaseRepository.EF.GuidPrimary
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /* Unmerged change from project 'NBaseRepository.EF (net5.0)'
    Before:
        using NBaseRepository.EF.Common;
    After:
        using NBaseRepository.EF.Common;
        using NBaseRepository;
        using NBaseRepository.EF;
        using NBaseRepository.EF.GuidPrimary;
    */
    using NBaseRepository.EF.Common;

    /// <summary>
    /// A repository that accepts and <see cref="TEntity"/> with a primary key of <see cref="Guid"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class NBaseRepository<TEntity> : NBaseRepository<TEntity, Guid>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TEntity}"/> class that has no default eager loading.
        /// </summary>
        /// <param name="context">A <see cref="DbContext"/>.</param>
        protected NBaseRepository(DbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TEntity}"/> class that has eager loading.
        /// </summary>
        /// <param name="context">A <see cref="DbContext"/>.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        protected NBaseRepository(DbContext context, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
            : base(context, includeFunc)
        {
        }
    }
}
