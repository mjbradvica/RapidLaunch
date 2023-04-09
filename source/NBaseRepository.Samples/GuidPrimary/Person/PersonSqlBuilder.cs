namespace NBaseRepository.Samples.GuidPrimary.Person
{
    using Animal;
    using Common;
    using NBaseRepository.GuidPrimary;

    public class PersonSqlBuilder : GuidSqlBuilder<GuidPerson>
    {
        protected override string DefaultInclude { get; } = SqlHelpers.InnerJoin<GuidPerson, GuidAnimal>();

        protected override Func<GuidPerson, IReadOnlyList<string>> EntityProperties { get; } = customer =>
            new List<string> { customer.Id.ToString(), customer.Name, customer.Age.ToString(), customer.GuidAnimal.Id.ToString() };
    }
}
