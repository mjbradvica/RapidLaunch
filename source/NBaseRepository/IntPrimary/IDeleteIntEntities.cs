namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IDeleteIntEntities<in TEntity> : IDeleteEntities<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
