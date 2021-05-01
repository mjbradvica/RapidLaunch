namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IIntQuery<T> : IQuery<T, int>
        where T : IIntEntity
    {
    }
}
