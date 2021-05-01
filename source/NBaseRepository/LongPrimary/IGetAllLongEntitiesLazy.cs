namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetAllLongEntitiesLazy<TEntity> : IGetAllEntitiesLazy<TEntity, long>
        where TEntity : ILongEntity
    {
    }
}
