namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGetByInt<TEntity> : IGetById<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
