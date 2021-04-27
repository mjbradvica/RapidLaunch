namespace NBaseRepository.IntPrimary
{
    using Common;

    public interface IUpdateIntEntity<in TEntity> : IUpdateEntity<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
