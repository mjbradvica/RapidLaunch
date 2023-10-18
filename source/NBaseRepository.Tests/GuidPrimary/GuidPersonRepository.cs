// <copyright file="GuidPersonRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using NBaseRepository.EF.GuidPrimary;

namespace NBaseRepository.Tests.GuidPrimary
{
    internal class GuidPersonRepository : NBaseRepository<Person>
    {
        public GuidPersonRepository(DbContext context)
            : base(context)
        {
        }
    }
}
