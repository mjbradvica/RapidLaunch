namespace NBaseRepository.Tests.GuidPrimary
{
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GuidPersonTests
    {
        [TestMethod]
        public async Task GetByIdWorks()
        {
            var person = new Person();

            using (var context = new TestingContext())
            {
                var repo = new GuidPersonRepository(context);

                await repo.AddEntityAsync(person);
            }

            using (var context = new TestingContext())
            {
                var repo = new GuidPersonRepository(context);

                var result = await repo.GetByIdAsync(person.Id);
            }
        }
    }
}
