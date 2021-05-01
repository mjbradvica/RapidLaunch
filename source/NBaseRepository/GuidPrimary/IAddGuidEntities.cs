namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// An interface used to describe a class that can add multiple entities of type <see cref="TEntity"/> at one time.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAddGuidEntities<in TEntity> : IAddEntities<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}
