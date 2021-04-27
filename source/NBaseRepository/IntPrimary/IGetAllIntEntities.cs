namespace NBaseRepository.IntPrimary
{
    using Common;

    public interface IGetAllIntEntities<TEntity> : IGetAllEntities<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
