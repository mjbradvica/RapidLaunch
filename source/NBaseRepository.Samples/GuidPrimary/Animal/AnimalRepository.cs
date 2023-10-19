// <copyright file="AnimalRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Data.SqlClient;
using NBaseRepository.ADO.GuidPrimary;
using NBaseRepository.Common;

namespace NBaseRepository.Samples.GuidPrimary.Animal
{
    internal class AnimalRepository : NBaseRepository<GuidAnimal>, IAnimalRepository
    {
        public AnimalRepository(SqlConnection sqlConnection, SqlBuilder<GuidAnimal, Guid> sqlBuilder)
            : base(sqlConnection, sqlBuilder, reader => new GuidAnimal(reader.GetGuid(0), reader.GetString(1)))
        {
        }
    }
}
