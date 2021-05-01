namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IAddIntEntities<in TEntity> : IAddEntities<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
