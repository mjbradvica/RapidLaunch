namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IUpdateIntEntity<in TEntity> : IUpdateEntity<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
