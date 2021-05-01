namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IDeleteIntEntities<in TEntity> : IDeleteEntities<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
