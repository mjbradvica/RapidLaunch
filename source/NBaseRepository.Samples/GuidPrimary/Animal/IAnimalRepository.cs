namespace NBaseRepository.Samples.GuidPrimary.Animal
{
    using NBaseRepository.GuidPrimary;

    internal interface IAnimalRepository
        : IAddEntityAsync<GuidAnimal>
    {
    }
}
