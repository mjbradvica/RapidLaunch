// <copyright file="RapidLaunchStatusTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using RapidLaunch.Common;

namespace RapidLaunch.Tests.Common
{
    /// <summary>
    /// Tests for the <see cref="RapidLaunchStatus"/> class.
    /// </summary>
    [TestClass]
    public class RapidLaunchStatusTests
    {
        /// <summary>
        /// Success method has correct properties.
        /// </summary>
        [TestMethod]
        public void SuccessHasCorrectProperties()
        {
            const int rowCount = 1;

            var status = RapidLaunchStatus.Success(rowCount);

            Assert.IsFalse(status.IsFailure);
            Assert.AreEqual(rowCount, status.RowCount);
            Assert.IsInstanceOfType<Exception>(status.Exception);
        }

        /// <summary>
        /// Failure method has correct properties.
        /// </summary>
        [TestMethod]
        public void FailureHasCorrectProperties()
        {
            var exception = new ArgumentNullException();

            var status = RapidLaunchStatus.Failed(exception);

            Assert.IsTrue(status.IsFailure);
            Assert.AreEqual(0, status.RowCount);
            Assert.AreEqual(exception, status.Exception);
        }
    }
}
