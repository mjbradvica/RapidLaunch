using NBaseRepository.Common;
using NBaseRepository.GuidPrimary;
using System;
using System.Collections.Generic;

namespace NBaseRepository.Dapper.Base.GuidPrimary
{
    public interface IGetAllGuidEntities<TEntity> : IGetAllEntities<TEntity, Guid, TEntity, TEntity>
        where TEntity : IGuidEntity
    {
        IReadOnlyList<TEntity> GetAllEntities<TFirst>(Func<TEntity, TFirst, TEntity> mappingFunc);
    }
}
