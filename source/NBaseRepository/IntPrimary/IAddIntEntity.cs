namespace NBaseRepository.IntPrimary
{
    using Common;

    public interface IAddIntEntity<in T> : IAddEntity<T, int>
        where T : IIntEntity
    {
    }
}