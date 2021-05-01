namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IUpdateIntEntities<in TEntity> : IUpdateEntities<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
