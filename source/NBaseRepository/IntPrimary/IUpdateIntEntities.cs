namespace NBaseRepository.IntPrimary
{
    using Common;

    public interface IUpdateIntEntities<in TEntity> : IUpdateEntities<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
