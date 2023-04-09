namespace NBaseRepository.Samples.GuidPrimary.Person
{
    using NBaseRepository.GuidPrimary;

    public interface IPersonRepository :
        IAddEntityAsync<GuidPerson>,
        IUpdateEntityAsync<GuidPerson>,
        IGetAllEntitiesAsync<GuidPerson>
    {
    }
}
