namespace NBaseRepository.IntPrimary
{
    using Common;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAddIntEntity<in T> : IAddEntity<T, int>
        where T : IIntEntity
    {
    }
}