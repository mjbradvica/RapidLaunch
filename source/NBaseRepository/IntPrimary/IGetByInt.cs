namespace NBaseRepository.IntPrimary
{
    using Common;

    public interface IGetByInt<TEntity> : IGetById<TEntity, int>
        where TEntity : IIntEntity
    {
    }
}
