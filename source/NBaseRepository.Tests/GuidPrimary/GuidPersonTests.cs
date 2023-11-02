// <copyright file="GuidPersonTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NBaseRepository.Tests.GuidPrimary
{
    /// <summary>
    /// Tests for <see cref="Guid"/> entities.
    /// </summary>
    [TestClass]
    public class GuidPersonTests
    {
        /// <summary>
        /// Ensures an entity can be retrieved by an identifier.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task GetByIdWorks()
        {
            var person = new Person();

            await using (var context = new TestingContext())
            {
                var repo = new GuidPersonRepository(context);

                await repo.AddEntityAsync(person);
            }

            await using (var context = new TestingContext())
            {
                var repo = new GuidPersonRepository(context);

                var result = await repo.GetByIdAsync(person.Id);
            }
        }
    }
}
