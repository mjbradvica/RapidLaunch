namespace NBaseRepository.Samples.GuidPrimary.Person
{
    using System.Data.SqlClient;
    using Animal;
    using Common;
    using NBaseRepository.ADO.GuidPrimary;

    public class PersonRepository : NBaseRepository<GuidPerson>, IPersonRepository
    {
        public PersonRepository(SqlConnection sqlConnection, SqlBuilder<GuidPerson, Guid> sqlBuilder)
            : base(
                sqlConnection,
                sqlBuilder,
                reader => new GuidPerson(
                    reader.GetGuid(0),
                    reader.GetString(1),
                    reader.GetInt32(2),
                    new GuidAnimal(
                        reader.GetGuid(4),
                        reader.GetString(5))))
        {
        }
    }
}
