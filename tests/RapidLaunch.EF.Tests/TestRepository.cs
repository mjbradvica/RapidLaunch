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
using RapidLaunch.EF.GuidPrimary;

namespace RapidLaunch.EF.Tests
{
    /// <summary>
    /// Test repository.
    /// </summary>
    public class TestRepository : RapidLaunchRepository<TestEntity>
    {
        /// <inheritdoc />
        public TestRepository(DbContext context)
            : base(context)
        {
        }

        /// <inheritdoc />
        public TestRepository(DbContext context, Func<IQueryable<TestEntity>, IQueryable<TestEntity>> includeFunc)
            : base(context, includeFunc)
        {
        }

        /// <summary>
        /// Test method for exception handling.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> class.</returns>
        /// <exception cref="Exception">The exception being thrown.</exception>
        public RapidLaunchStatus TestExceptionHandler(TestEntity entity)
        {
            return ExecuteCommand(
                () =>
            {
                Context.Set<TestEntity>().Add(entity);

                var rowCount = Context.SaveChanges();

                return (rowCount, new List<TestEntity> { entity });
            },
                (_, _) => throw new Exception());
        }

        /// <summary>
        /// Test method for exception handling.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A <see cref="RapidLaunchStatus"/> class.</returns>
        /// <exception cref="Exception">The exception being thrown.</exception>
        public async Task<RapidLaunchStatus> TestExceptionHandlerAsync(TestEntity entity)
        {
            return await ExecuteCommandAsync(
                async () =>
                {
                    await Context.Set<TestEntity>().AddAsync(entity);

                    var rowCount = await Context.SaveChangesAsync();

                    return (rowCount, new List<TestEntity> { entity });
                },
                CancellationToken.None,
                (_, _) => throw new Exception());
        }
    }
}
