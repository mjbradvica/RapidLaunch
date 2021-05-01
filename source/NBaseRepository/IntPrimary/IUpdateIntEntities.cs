namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IUpdateIntEntities<in TEntity> : IUpdateEntities<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
