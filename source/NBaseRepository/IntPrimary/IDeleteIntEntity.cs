namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IDeleteIntEntity<in TEntity> : IDeleteEntity<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
