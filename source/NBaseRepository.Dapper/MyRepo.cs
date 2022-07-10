using System;
using System.Data.SqlClient;
using Dapper;
using NBaseRepository.Common;
using NBaseRepository.SQL;

namespace NBaseRepository.Dapper
{
    internal class Airplane : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }

    internal class MyRepo : BaseRepository<Airplane, Airplane, Guid>
    {
        public MyRepo(SqlConnection sqlConnection, SqlBuilder<Airplane, Guid> sqlBuilder)
            : base(sqlConnection, sqlBuilder, airplane => airplane)
        {
        }
    }

    internal class Testerino
    {
        public void DoStuff()
        {
            var repo = new MyRepo(null, null);

            repo.GetAllEntities((connection, s) =>
            {
                return connection.Query<Airplane, Airplane, Airplane>(s, (airplane, airplane1) => airplane);
            });
        }
    }
}
