// <copyright file="SqlBuilderTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Tests.Common.SqlBuilder
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        [TestMethod]
        public void SelectAll_NoDefaultInclude_IsCorrect()
        {
            var sql = _builder.SelectAll(false).SqlStatement;

            const string expected = "SELECT * FROM dbo.Person";

            Assert.AreEqual(expected, sql);
        }

        [TestMethod]
        public void SelectAll_WithDefaultInclude_IsCorrect()
        {
            var sql = _builder.SelectAll().SqlStatement;

            const string expected = "SELECT * FROM dbo.Person INNER JOIN dbo.Pets ON dbo.Person.Id = dbo.Pet.PersonId";

            Assert.AreEqual(expected, sql);
        }
    }
}
