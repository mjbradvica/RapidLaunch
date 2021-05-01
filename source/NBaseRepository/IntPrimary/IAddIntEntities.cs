namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAddIntEntities<in TEntity> : IAddEntities<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
