namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// An interface used to describe a class that can add multiple entities of type <see cref="TEntity"/> at one time.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAddEntitiesAsync<in TEntity> : IAddEntitiesAsync<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}
