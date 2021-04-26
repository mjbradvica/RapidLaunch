namespace NBaseRepository.IntPrimary
{
    using Common;

    public interface IIntQuery<T> : IQuery<T, int>
        where T : IIntEntity
    {
    }
}
