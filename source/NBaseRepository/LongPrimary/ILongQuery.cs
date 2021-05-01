namespace NBaseRepository.LongPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILongQuery<T> : IQuery<T, long>
        where T : ILongEntity
    {
    }
}
