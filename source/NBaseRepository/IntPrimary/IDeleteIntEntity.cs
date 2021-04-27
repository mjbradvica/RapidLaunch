namespace NBaseRepository.IntPrimary
{
    using Common;

    public interface IDeleteIntEntity<in TEntity> : IDeleteEntity<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
