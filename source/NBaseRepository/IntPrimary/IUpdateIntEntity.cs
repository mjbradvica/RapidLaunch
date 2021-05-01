namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IUpdateIntEntity<in TEntity> : IUpdateEntity<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
