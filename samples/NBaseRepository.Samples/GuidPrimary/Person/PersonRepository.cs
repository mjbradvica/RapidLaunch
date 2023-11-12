// <copyright file="PersonRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Data.SqlClient;
using NBaseRepository.ADO.GuidPrimary;
using NBaseRepository.Common;
using NBaseRepository.Samples.GuidPrimary.Animal;

namespace NBaseRepository.Samples.GuidPrimary.Person
{
    /// <summary>
    /// Sample person repository.
    /// </summary>
    public class PersonRepository : NBaseRepository<GuidPerson>, IPersonRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
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

        /// <inheritdoc/>
        public async Task<IReadOnlyList<GuidPerson>> GetAllByName(string name)
        {
            return await ExecuteQueryAsync(
                SqlBuilder
                    .SelectAll()
                    .WhereEqual(x => x.Name, name)
                    .OrderBy(x => x.Age)
                    .SqlStatement);
        }
    }
}
