// <copyright file="GuidPersonTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Tests.GuidPrimary
{
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GuidPersonTests
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
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
