namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// An interface used to describe a class that can update a range of entities of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IUpdateGuidEntities<in TEntity> : IUpdateEntities<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
