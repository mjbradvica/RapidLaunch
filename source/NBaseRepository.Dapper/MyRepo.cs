using System.Data.SqlClient;
using System.Collections.Generic;

namespace NBaseRepository.Dapper
{
    internal class Airplane : IEntity
    {
        public Guid Id { get; set; }
    }

    internal class Route : IEntity
    {
        public Guid Id { get; }
    }

    internal interface IAirplaneRepo : IGetAllGuidEntities<Airplane>
    {

    }

    internal class MyRepo : BaseRepository<Airplane, Airplane, Guid>, IAirplaneRepo
    {
        public MyRepo(SqlConnection sqlConnection, SqlBuilder<Airplane, Guid> sqlBuilder)
            : base(sqlConnection, sqlBuilder, airplane => airplane)
        {
        }

        public override IReadOnlyList<Airplane> GetAllEntities()
        {
            return GetAllEntities<Airplane, Route, Route>((airplane, route, arg3) => new Airplane());
        }
    }
}
