namespace NBaseRepository.Dapper
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Common;
    using GuidPrimary;

    internal class Airplane : IEntity
    {
        public Guid Id { get; set; }
    }

    internal class Route : IEntity
    {
        public Guid Id { get; }
    }

    internal interface IAirplaneRepo : IGetAllEntities<Airplane>
    {
    }

    internal class MyRepo : NBaseRepository<Airplane, Airplane, Guid>, IAirplaneRepo
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
