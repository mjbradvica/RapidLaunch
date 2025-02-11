// <copyright file="SqlBuilderTests.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using RapidLaunch.Common;

namespace RapidLaunch.Tests.Common
{
    /// <summary>
    /// Tests for the <see cref="SqlBuilder{TEntity,TId}"/> class.
    /// </summary>
    [TestClass]
    public class SqlBuilderTests
    {
        /// <summary>
        /// Table name instantiation is correct.
        /// </summary>
        [TestMethod]
        public void Constructor_ExplicitTableName_IsCorrect()
        {
            const string tableName = "tableName";

            var builder = new TestSqlBuilder(tableName);

            var selectAll = builder.SelectAll(false).SqlStatement;

            Assert.IsTrue(selectAll.Contains(tableName));
        }

        /// <summary>
        /// Table name instantiation is correct.
        /// </summary>
        [TestMethod]
        public void Constructor_Default_IsCorrect()
        {
            var builder = new TestSqlBuilder();

            var selectAll = builder.SelectAll(false).SqlStatement;

            Assert.IsTrue(selectAll.Contains("dbo.TestEntity"));
        }

        /// <summary>
        /// Sql statement is reset with new command.
        /// </summary>
        [TestMethod]
        public void SqlStatement_IsCorrect()
        {
            var builder = new TestSqlBuilder();

            _ = builder.SelectAll(false).SqlStatement;

            var delete = builder.Delete(new TestEntity()).SqlStatement;

            Assert.IsFalse(delete.Contains('*'));
        }

        /// <summary>
        /// Default select all has the include statement.
        /// </summary>
        [TestMethod]
        public void SelectAll_Default_HasIncludeStatement()
        {
            var builder = new TestSqlBuilder();

            var result = builder.SelectAll().SqlStatement;

            Assert.IsTrue(result.Contains("IncludeStatement"));
        }

        /// <summary>
        /// Select all, no include statement is correct.
        /// </summary>
        [TestMethod]
        public void SelectAll_NoInclude_DoesNotIncludeStatement()
        {
            var builder = new TestSqlBuilder();

            var result = builder.SelectAll(false).SqlStatement;

            Assert.IsFalse(result.Contains("IncludeStatement"));
        }

        /// <summary>
        /// Get by id has the identifier.
        /// </summary>
        [TestMethod]
        public void GetById_IsCorrect()
        {
            var id = Guid.NewGuid();

            var builder = new TestSqlBuilder();

            var result = builder.GetById(id).SqlStatement;

            Assert.IsTrue(result.Contains(id.ToString()));
        }
    }
}
