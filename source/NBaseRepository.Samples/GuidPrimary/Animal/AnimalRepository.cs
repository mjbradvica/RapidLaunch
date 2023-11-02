// <copyright file="AnimalRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Data.SqlClient;
using NBaseRepository.ADO.GuidPrimary;
using NBaseRepository.Common;

namespace NBaseRepository.Samples.GuidPrimary.Animal
{
    /// <summary>
    /// Sample repository.
    /// </summary>
    internal class AnimalRepository : NBaseRepository<GuidAnimal>, IAnimalRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnimalRepository"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        public AnimalRepository(SqlConnection sqlConnection, SqlBuilder<GuidAnimal, Guid> sqlBuilder)
            : base(sqlConnection, sqlBuilder, reader => new GuidAnimal(reader.GetGuid(0), reader.GetString(1)))
        {
        }
    }
}
