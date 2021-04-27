namespace NBaseRepository.IntPrimary
{
    using Common;

    public interface IAddIntEntities<in TEntity> : IAddEntities<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
