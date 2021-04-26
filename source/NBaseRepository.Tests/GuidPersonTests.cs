namespace NBaseRepository.Tests
{
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GuidPersonTests
    {
        [TestMethod]
        public async Task GetByIdWorks()
        {
            var person = new GuidPerson();

            using (var context = new TestContext())
            {
                var repo = new GuidPersonRepository(context);

                await repo.AddEntity(person);
            }

            using (var context = new TestContext())
            {
                var repo = new GuidPersonRepository(context);

                var result = await repo.GetById(person.Id);
            }
        }
    }
}
