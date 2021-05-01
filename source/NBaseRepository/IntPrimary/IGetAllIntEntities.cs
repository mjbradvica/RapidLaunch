namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetAllIntEntities<TEntity> : IGetAllEntities<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
