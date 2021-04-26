namespace NBaseRepository.IntPrimary
{
    using Common;

    public interface IIntAddEntity<in T> : IAddEntity<T, int>
        where T : IIntEntity
    {
    }
}