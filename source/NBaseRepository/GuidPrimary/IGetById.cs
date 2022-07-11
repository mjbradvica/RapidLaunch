namespace NBaseRepository.GuidPrimary
{
    using System;
    using Common;

    /// <summary>
    /// An interface used to describe a class that can retrieve a single entity of type <see cref="TEntity"/> by Id of type <see cref="Guid"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetById<out TEntity> : IGetById<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}