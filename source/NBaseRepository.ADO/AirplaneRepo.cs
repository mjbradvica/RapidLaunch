using NBaseRepository.GuidPrimary;
using NBaseRepository.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NBaseRepository.ADO
{
    internal class Airplane : IEntity
    {
        public Guid Id { get; }
    }

    internal interface IAirplaneRepo : IGetAllGuidEntities<Airplane>
    {

    }

    internal class AirplaneRepo : BaseGuidRepository<Airplane>, IAirplaneRepo
    {
        public AirplaneRepo(SqlBuilder<Airplane, Guid> sqlBuilder, SqlConnection sqlConnection)
            : base(sqlBuilder, sqlConnection, x => new Airplane())
        {
        }

        public override IReadOnlyList<Airplane> GetAllEntities()
        {
            return GetAllEntities(reader => new Airplane());
        }
    }
}
