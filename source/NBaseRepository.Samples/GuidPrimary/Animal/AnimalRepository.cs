// <copyright file="AnimalRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Samples.GuidPrimary.Animal
{
    using System.Data.SqlClient;
    using NBaseRepository.Common;
    using NBaseRepository.ADO.GuidPrimary;

    internal class AnimalRepository : NBaseRepository<GuidAnimal>, IAnimalRepository
    {
        public AnimalRepository(SqlConnection sqlConnection, SqlBuilder<GuidAnimal, Guid> sqlBuilder)
            : base(sqlConnection, sqlBuilder, reader => new GuidAnimal(reader.GetGuid(0), reader.GetString(1)))
        {
        }
    }
}
