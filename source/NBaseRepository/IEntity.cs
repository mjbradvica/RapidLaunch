namespace NBaseRepository
{
    public interface IEntity<out T>
    {
        public T Id { get; }
    }
}
