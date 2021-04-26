namespace NBaseRepository.Common
{
    public interface IEntity<out T>
    {
        T Id { get; }
    }
}
