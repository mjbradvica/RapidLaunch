namespace NBaseRepository.IntPrimary
{
    using Common;

    public interface IGetAllIntEntitiesLazy<TEntity> : IGetAllEntitiesLazy<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
