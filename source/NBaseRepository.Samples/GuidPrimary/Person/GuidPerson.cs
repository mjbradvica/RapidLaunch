namespace NBaseRepository.Samples.GuidPrimary.Person
{
    using Animal;
    using NBaseRepository.GuidPrimary;

    public class GuidPerson : IEntity
    {
        public GuidPerson(string name, int age, GuidAnimal guidAnimal)
            : this(Guid.NewGuid(), name, age, guidAnimal)
        {
        }

        public GuidPerson(Guid id, string name, int age, GuidAnimal guidAnimal)
        {
            Id = id;
            Name = name;
            Age = age;
            GuidAnimal = guidAnimal;
        }

        public Guid Id { get; }

        public string Name { get; }

        public int Age { get; }

        public GuidAnimal GuidAnimal { get; }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Age: {Age} Pet: {GuidAnimal.Name} \n";
        }
    }
}
