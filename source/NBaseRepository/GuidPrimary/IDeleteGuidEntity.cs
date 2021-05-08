namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// An interface used to describe a class that can delete an entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IDeleteGuidEntity<in TEntity> : IDeleteEntity<TEntity, Guid>
        where TEntity : IGuidEntity
    {
    }
}