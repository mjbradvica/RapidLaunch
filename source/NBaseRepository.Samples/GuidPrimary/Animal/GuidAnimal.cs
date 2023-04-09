namespace NBaseRepository.Samples.GuidPrimary.Animal
{
    using NBaseRepository.GuidPrimary;

    public class GuidAnimal : IEntity
    {
        public GuidAnimal(string name)
            : this(Guid.NewGuid(), name)
        {
        }

        public GuidAnimal(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }

        public string Name { get; }
    }
}
