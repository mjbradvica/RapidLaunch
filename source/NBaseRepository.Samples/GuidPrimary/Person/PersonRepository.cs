// <copyright file="PersonRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Data.SqlClient;
using NBaseRepository.Samples.GuidPrimary.Animal;
using NBaseRepository.Common;
using NBaseRepository.ADO.GuidPrimary;

namespace NBaseRepository.Samples.GuidPrimary.Person
{
    public class PersonRepository : NBaseRepository<GuidPerson>, IPersonRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlBuilder"></param>
        public PersonRepository(SqlConnection sqlConnection, SqlBuilder<GuidPerson, Guid> sqlBuilder)
            : base(
                sqlConnection,
                sqlBuilder,
                reader => new GuidPerson(
                    reader.GetGuid(0),
                    reader.GetString(1),
                    reader.GetInt32(2),
                    new GuidAnimal(
                        reader.GetGuid(4),
                        reader.GetString(5))))
        {
        }
    }
}
