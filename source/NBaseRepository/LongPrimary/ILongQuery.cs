namespace NBaseRepository.LongPrimary
{
    using Common;

    public interface ILongQuery<T> : IQuery<T, long>
        where T : ILongEntity
    {
    }
}
