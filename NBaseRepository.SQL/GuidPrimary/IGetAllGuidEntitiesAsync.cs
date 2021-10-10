namespace NBaseRepository.SQL.GuidPrimary
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using NBaseRepository.GuidPrimary;

    public interface IGetAllGuidEntitiesAsync<TEntity> : IGetAllEntitiesAsync<TEntity, Guid>
        where TEntity : IGuidEntity
    {
        Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(Func<IEnumerable<object>, TEntity> conversionFunc, CancellationToken cancellationToken);
    }
}
