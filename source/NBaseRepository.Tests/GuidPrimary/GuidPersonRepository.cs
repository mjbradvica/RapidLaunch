// <copyright file="GuidPersonRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.EntityFrameworkCore;
using NBaseRepository.EF.GuidPrimary;

namespace NBaseRepository.Tests.GuidPrimary
{
    /// <summary>
    /// Test repository for <see cref="Guid"/> entities.
    /// </summary>
    internal class GuidPersonRepository : NBaseRepository<Person>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidPersonRepository"/> class.
        /// </summary>
        /// <param name="context">A instance of the <see cref="DbContext"/> class.</param>
        public GuidPersonRepository(DbContext context)
            : base(context)
        {
        }
    }
}
