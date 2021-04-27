namespace NBaseRepository.IntPrimary
{
    using Common;

    public interface IDeleteIntEntities<in TEntity> : IDeleteEntities<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
