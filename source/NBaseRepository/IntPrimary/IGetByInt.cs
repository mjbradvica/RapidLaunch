namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetByInt<TEntity> : IGetById<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
