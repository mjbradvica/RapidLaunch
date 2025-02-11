// <copyright file="TestRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.Common;
using RapidLaunch.EF.Common;
using RapidLaunch.EF.Tests.GuidPrimary;

namespace RapidLaunch.EF.Tests.Common
{
    /// <summary>
    /// Test repository.
    /// </summary>
    public class TestRepository : RapidLaunchRepository<TestGuidEntity, Guid>
    {
        /// <inheritdoc />
        public TestRepository(DbContext context)
            : base(context)
        {
        }

        /// <inheritdoc />
        public TestRepository(DbContext context, Func<IQueryable<TestGuidEntity>, IQueryable<TestGuidEntity>> includeFunc)
            : base(context, includeFunc)
        {
        }

        /// <summary>
        /// Test method for exception handling.
        /// </summary>
        /// <param name="guidEntity">The guidEntity to add.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> class.</returns>
        /// <exception cref="Exception">The exception being thrown.</exception>
        public RapidLaunchStatus TestExceptionHandler(TestGuidEntity guidEntity)
        {
            return ExecuteCommand(
                () =>
            {
                Context.Set<TestGuidEntity>().Add(guidEntity);

                var rowCount = Context.SaveChanges();

                return (rowCount, new List<TestGuidEntity> { guidEntity });
            },
                (_, _) => throw new Exception());
        }

        /// <summary>
        /// Test method for exception handling.
        /// </summary>
        /// <param name="guidEntity">The guidEntity to add.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> class.</returns>
        /// <exception cref="Exception">The exception being thrown.</exception>
        public async Task<RapidLaunchStatus> TestExceptionHandlerAsync(TestGuidEntity guidEntity)
        {
            return await ExecuteCommandAsync(
                async () =>
                {
                    await Context.Set<TestGuidEntity>().AddAsync(guidEntity);

                    var rowCount = await Context.SaveChangesAsync();

                    return (rowCount, new List<TestGuidEntity> { guidEntity });
                },
                CancellationToken.None,
                (_, _) => throw new Exception());
        }
    }
}
