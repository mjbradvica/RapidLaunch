// <copyright file="SqlBuilderTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NBaseRepository.Tests.Common.SqlBuilder
{
    /// <summary>
    /// Tests for the sql builder class.
    /// </summary>
    [TestClass]
    public class SqlBuilderTests
    {
        private readonly TestSqlBuilder _builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlBuilderTests"/> class.
        /// </summary>
        public SqlBuilderTests()
        {
            _builder = new TestSqlBuilder();
        }

        /// <summary>
        /// Ensures the default get all is correct.
        /// </summary>
        [TestMethod]
        public void SelectAllNoDefaultIncludeIsCorrect()
        {
            var sql = _builder.SelectAll(false).SqlStatement;

            const string expected = "SELECT * FROM dbo.Person";

            Assert.AreEqual(expected, sql);
        }

        /// <summary>
        /// Ensure the get all with include statements is correct.
        /// </summary>
        [TestMethod]
        public void SelectAllWithDefaultIncludeIsCorrect()
        {
            var sql = _builder.SelectAll().SqlStatement;

            const string expected = "SELECT * FROM dbo.Person INNER JOIN dbo.Pets ON dbo.Person.Id = dbo.Pet.PersonId";

            Assert.AreEqual(expected, sql);
        }
    }
}
