namespace NBaseRepository.Common
{
    public interface IEntity<out TId>
    {
        TId Id { get; }
    }
}
