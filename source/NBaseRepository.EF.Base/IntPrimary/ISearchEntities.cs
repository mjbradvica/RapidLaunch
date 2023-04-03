namespace NBaseRepository.EF.Base.IntPrimary
{
    using Common;
    using NBaseRepository.IntPrimary;

    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins for type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ISearchEntities<TEntity> : ISearchEntities<TEntity, int>
        where TEntity : IEntity
    {
    }
}